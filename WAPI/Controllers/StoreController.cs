using Newtonsoft.Json;
using SuperProject;
using SuperProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace WAPI.Controllers
{
    public class StoreController: ApiController
    {
        [HttpGet]
        [Route("/api/getstore")]
        public HttpResponseMessage GetStore()
        {
            StoreService storeservice = new StoreService();//Servicios
            List<Store> store = storeservice.Read();
            string productsJSON = JsonConvert.SerializeObject(store, Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(productsJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpPost, ActionName("postInfo")]
        public HttpResponseMessage PostInfo(Object content)
        {
            try
            {
                String storeJSON = content.ToString();
                Store store = JsonConvert.DeserializeObject<Store>(storeJSON);
                StoreService ss = new StoreService();
                var response = Request.CreateResponse(HttpStatusCode.Unused);
                if (ss.Create(store))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Store created\n" + lista(ss.Read()), Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("An error has ocurred creating the store", Encoding.UTF8, "application/json");
                }
                return response;
            }
            catch(Exception e)
            {
                var response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                response.Content = new StringContent(("Error"+e),Encoding.UTF8, "application/json");
                return response;
            }
        }

        /*[HttpPut, ActionName("updateInfo")]
        public HttpResponseMessage UpdateInfo(Object res)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(res.ToString(), Encoding.UTF8, "application/json");
            return response;
        }*/

        [HttpDelete, ActionName("DeleteInfo")]
        public HttpResponseMessage DeleteInfo(Object id)
        {
            try
            {
                String storeJSON = content.ToString();
                string key = JsonConvert.DeserializeObject<String>(storeJSON);
                storeService ss = new StoreService();
                var response = Request.CreateResponse(HttpStatusCode.Unused);
                if (ss.Delete(key))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Store deleted\n" + lista(ss.Read()), Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("An error has ocurred deleting the store", Encoding.UTF8, "application/json");
                }
                return response;
            }
            catch (Exception e)
            {
                var response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                response.Content = new StringContent(("Error" + e), Encoding.UTF8, "application/json");
                return response;
            }
        }
    }
}
