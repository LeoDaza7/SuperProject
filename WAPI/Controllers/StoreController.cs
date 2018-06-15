using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAPI.Controllers
{
    public class StoreController: ApiController
    {
        [HttpGet]
        [Route("api/getusers")]
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
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(content.ToString(), Encoding.UTF8, "application/json");
                return response;
            }
            catch(Exception e)
            {
                Console.WriteLine("Something went wrong '{0}'",e);
            }
        }

        /*[HttpPut, ActionName("updateInfo")]
        public HttpResponseMessage UpdateInfo(Object res)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(res.ToString(), Encoding.UTF8, "application/json");
            return response;
        }

        [HttpDelete, ActionName("DeleteInfo")]
        public HttpResponseMessage DeleteInfo(Object id)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(id.ToString(), Encoding.UTF8, "application/json");
            return response;
        }*/
    }
}
}