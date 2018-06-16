﻿using Newtonsoft.Json;
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

        [HttpGet]
        [Route("api/getstore/{key}")]
        public HttpResponseMessage GetStore(string key)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            StoreService storeservice = new StoreService();//Servicios
            List<Store> store = storeservice.Read();
            int id = storeservice.GetIndex(key);
            if (id!=-1)
            {
                Store st = store[id];
                string productsJSON = JsonConvert.SerializeObject(st, Formatting.Indented);
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
                Store store = JsonConvert.DeserializeObject<Store>(storeJSON);
                StoreService ss = new StoreService();
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
            }
            catch
            {
                response.Content = new StringContent("Error",Encoding.UTF8, "application/json");
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
                Store store = JsonConvert.DeserializeObject<Store>(content.ToString());
                StoreService ss = new StoreService();
                ss.Read();
                if (ss.Update(key, store))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Store Updated", Encoding.UTF8, "application/json");
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
        [Route("api/deletestore/{key}")]
        public HttpResponseMessage DeleteInfo(string key)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                StoreService ss = new StoreService();
                ss.Read();
                if (ss.Delete(key))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Store deleted\n", Encoding.UTF8, "application/json");
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
