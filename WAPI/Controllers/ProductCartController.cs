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
    public class ProductCartController: ApiController
    {
        [HttpGet]
        [Route("api/getproductcart")]
        public HttpResponseMessage GetProductCart()
        {
            ProductCartService productcartservice = new ProductCartService();//Servicios
            List<ProductCart> productcart = productcartservice.Read();
            string productcartJSON = JsonConvert.SerializeObject(productcart, Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(productcartJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet]
        [Route("api/getproductcart/{key}")]
        public HttpResponseMessage GetProductCart(string key)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            ProductCartService productcartservice = new ProductCartService();//Servicios
            List<ProductCart> productcart = productcartservice.Read();
            int id = productcartservice.GetProductCartIndex(key);
            if (id != -1)
            {
                ProductCart pc = productcart[id];
                string productcartJSON = JsonConvert.SerializeObject(pc, Formatting.Indented);
                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(productcartJSON, Encoding.UTF8, "application/json");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                response.Content = new StringContent("Error", Encoding.UTF8, "application/json");
            }
            return response;

        }

        [HttpPost]
        [Route("api/postproductart")]
        public HttpResponseMessage PostCart(Object content)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                String productcartJSON = content.ToString();
                ProductCart productcart = JsonConvert.DeserializeObject<ProductCart>(productcartJSON);
                ProductCartService pcs = new ProductCartService();
                if (pcs.Create(productcart))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Product Cart created", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("An error has ocurred creating the Product Cart", Encoding.UTF8, "application/json");
                }
            }
            catch
            {
                response.Content = new StringContent("Error", Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpPut]
        [Route("api/updateproductcart/{key}")]
        public HttpResponseMessage UpdateProductCart(Object content, string key)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                ProductCart productcart = JsonConvert.DeserializeObject<ProductCart>(content.ToString());
                ProductCartService pcs = new ProductCartService();
                pcs.Read();
                if (pcs.Update(key, productcart))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Product Cart Updated", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("An error has ocurred updating Product Cart", Encoding.UTF8, "application/json");
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
        [Route("api/deleteproductcart/{id}")]
        public HttpResponseMessage DeleteProductCart(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                ProductCartService pcs = new ProductCartService();
                pcs.Read();
                if (pcs.Delete(id))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Product Cart deleted", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("An error has ocurred deleting the Product Cart", Encoding.UTF8, "application/json");
                }
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                response.Content = new StringContent("Error", Encoding.UTF8, "application/json");
            }
            return response;
        }
    }
}