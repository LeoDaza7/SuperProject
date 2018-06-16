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
    public class CategoryController: ApiController
    {
        [HttpGet]
        [Route("api/getstore")]
        public HttpResponseMessage GetStore()
        {
            CategoryService categoryservice = new CategoryService();//Servicios
            List<Category> category = categoryservice.Read();
            string productsJSON = JsonConvert.SerializeObject(category, Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(productsJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet]
        [Route("api/getstore/{key}")]
        public HttpResponseMessage GetStore(string key)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            CategoryService categoryservice = new CategoryService();//Servicios
            List<Category> category = categoryservice.Read();
            int id = categoryservice.GetIndex(key);
            if (id != -1)
            {
                Category ct = category[id];
                string productsJSON = JsonConvert.SerializeObject(ct, Formatting.Indented);
                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(productsJSON, Encoding.UTF8, "application/json");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                response.Content = new StringContent("Error", Encoding.UTF8, "application/json");
            }
            return response;

        }

        [HttpPost, ActionName("postInfo")]
        [Route("api/poststore")]
        public HttpResponseMessage PostInfo(Object content)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                String storeJSON = content.ToString();
                Category category = JsonConvert.DeserializeObject<Category>(storeJSON);
                CategoryService cs = new CategoryService();
                if (cs.Create(category))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Category created", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("An error has ocurred creating the category", Encoding.UTF8, "application/json");
                }
            }
            catch
            {
                response.Content = new StringContent("Error", Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpPut]
        [Route("api/updatestore/{key}")]
        public HttpResponseMessage UpdateInfo(Object content, string key)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                Category category = JsonConvert.DeserializeObject<Category>(content.ToString());
                CategoryService cs = new CategoryService();
                cs.Read();
                if (cs.Update(key, category))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Category Updated", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("An error has ocurred updating Category", Encoding.UTF8, "application/json");
                }
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                response.Content = new StringContent("Error", Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpDelete, ActionName("DeleteInfo")]
        [Route("api/deletestore/{id}")]
        public HttpResponseMessage DeleteInfo(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                CategoryService cs = new CategoryService();
                cs.Read();
                if (cs.Delete(id))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Category deleted", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("An error has ocurred deleting the store", Encoding.UTF8, "application/json");
                }
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                response.Content = new StringContent(("Error"), Encoding.UTF8, "application/json");
            }
            return response;
        }
    }
}
