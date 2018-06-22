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
using System.Web.Http.Cors;

namespace WAPI.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/getusers")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage GetUsers()
        {
            UserService userservice= new UserService();
            List<User> users = userservice.Read();
            string productsJSON = JsonConvert.SerializeObject(users, Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(productsJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet]
        [Route("api/getusers/{key}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage GetUsers(string key)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            UserService userservice = new UserService();
            List<User> user = userservice.Read();
            int id = userservice.GetIndex(key);
            if (id != -1)
            {
                User u = user[id];
                string cartJSON = JsonConvert.SerializeObject(u, Formatting.Indented);
                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(cartJSON, Encoding.UTF8, "application/json");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                response.Content = new StringContent("Error", Encoding.UTF8, "application/json");
            }
            return response;

        }

        [HttpPost]
        [Route("api/postuser")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage PosUser(Object user)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                String userJSON = user.ToString();
                User u = JsonConvert.DeserializeObject<User>(userJSON);
                UserService us = new UserService();
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
        [Route("api/updateuser/{key}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage UpdateInfo(Object user, string key)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                User u = JsonConvert.DeserializeObject<User>(user.ToString());
                UserService us = new UserService();
                if (us.Update(key,u))
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
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage DeleteInfo(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                UserService us = new UserService();
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