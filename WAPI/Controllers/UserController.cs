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

        [HttpPost]
        [Route("api/postuser")]
        public HttpResponseMessage PosUser(Object user)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                String userJSON = user.ToString();
                User u = JsonConvert.DeserializeObject<User>(userJSON);
                UserService us = new UserService();
                us.Read();
                if (us.Create(u))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("usuario creado", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("Error al crear usuario", Encoding.UTF8, "application/json");
                }
            }catch
            {
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                response.Content = new StringContent("Error, solo error", Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpPut]
        [Route("api/updateuser")]
        public HttpResponseMessage UpdateInfo(Object user)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                User u = JsonConvert.DeserializeObject<User>(user.ToString());
                UserService us = new UserService();
                us.Read();
                if (us.Update(u.Username,u))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("usuario actualizado", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("Error al actualizar usuario", Encoding.UTF8, "application/json");
                }
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                response.Content = new StringContent("Error, solo error", Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpDelete]
        [Route("api/deleteuser/{id}")]
        public HttpResponseMessage DeleteInfo(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                UserService us = new UserService();
                us.Read();
                if (us.Delete(id))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("usuario eliminado", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("Error al eliminar usuario", Encoding.UTF8, "application/json");
                }
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                response.Content = new StringContent("Error, solo error", Encoding.UTF8, "application/json");
            }
            return response;
        }
    }
}