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
        [Route("api/getstore")]
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
        [Route("api/poststore")]
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
                    response.Content = new StringContent("Store created", Encoding.UTF8, "application/json");
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
        [Route("api/putstore/{id}")]
        public HttpResponseMessage UpdateInfo(Object res)
        {
            
        }*/

        [HttpDelete, ActionName("DeleteInfo")]
        [Route("api/deletestore/{id}")]
        public HttpResponseMessage DeleteInfo(string id)
        {
            try
            {
                var response = Request.CreateResponse(HttpStatusCode.Unused);
                StoreService ss = new StoreService();
                ss.Read();
                if (ss.Delete(id))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Store deleted\n", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("An error has ocurred deleting the store", Encoding.UTF8, "application/json");
                }
                return response;
            }
            catch
            {
                var response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                response.Content = new StringContent(("Error"), Encoding.UTF8, "application/json");
                return response;
            }
        }
    }
}
