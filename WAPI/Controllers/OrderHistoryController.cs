using Models;
using Newtonsoft.Json;
using Services;
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
    public class OrderHistoryController:ApiController
    {
        [HttpGet]
        [Route("api/getorderhistory")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage GetOrderHistory()
        {
            OrderHistoryService order = new OrderHistoryService();
            List<OrderHistory> oh = order.Read();
            string categoryJSON = JsonConvert.SerializeObject(oh, Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(categoryJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet]
        [Route("api/getorderhistory/{key}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage GetOrderHistory(string key)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            OrderHistoryService order = new OrderHistoryService();
            List<OrderHistory> oh = order.Read();
            int id = order.GetIndex(key);
            if (id != -1)
            {
                OrderHistory ct = oh[id];
                string categoryJSON = JsonConvert.SerializeObject(ct, Formatting.Indented);
                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(categoryJSON, Encoding.UTF8, "application/json");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                response.Content = new StringContent("Error", Encoding.UTF8, "application/json");
            }
            return response;

        }

        [HttpPost]
        [Route("api/postorderhistory")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage PostOrderHistory(Object content)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                String categoryJSON = content.ToString();
                OrderHistory order = JsonConvert.DeserializeObject<OrderHistory>(categoryJSON);
                OrderHistoryService cs = new OrderHistoryService();
                if (cs.Create(order))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Order created", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("An error has ocurred creating the Order", Encoding.UTF8, "application/json");
                }
            }
            catch
            {
                response.Content = new StringContent("Error", Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpPut]
        [Route("api/updateorderhistory/{key}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage UpdateOrderHistory(Object content, string key)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                OrderHistory order = JsonConvert.DeserializeObject<OrderHistory>(content.ToString());
                OrderHistoryService cs = new OrderHistoryService();
                if (cs.Update(key, order))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Order Updated", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("An error has ocurred updating Order", Encoding.UTF8, "application/json");
                }
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                response.Content = new StringContent("Error", Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpDelete]
        [Route("api/deleteorderhistory/{id}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage DeleteOrderHistory(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                OrderHistoryService cs = new OrderHistoryService();
                if (cs.Delete(id))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("order deleted", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("An error has ocurred deleting the Order", Encoding.UTF8, "application/json");
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