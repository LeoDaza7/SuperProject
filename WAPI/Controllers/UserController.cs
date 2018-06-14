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
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/getusers")]
        public HttpResponseMessage GetUsers()
        {
            UserService userservice= new UserService();//Servicios
            List<User> users = userservice.Read();
            string productsJSON = JsonConvert.SerializeObject(users, Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(productsJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpPost, ActionName("postInfo")]
        public HttpResponseMessage PostInfo(Object content)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(content.ToString(), Encoding.UTF8, "application/json");
            return response;
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