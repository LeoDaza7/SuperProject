using Newtonsoft.Json;
using SuperProject;
using SuperProject.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WAPI.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("api/getproducts")]
        [EnableCors(origins: "http://<ip_address>:4200", headers: "*", methods: "*")]
        public HttpResponseMessage GetProducts()
        {
            ProductService ps = new ProductService();
            List<Product> products = ps.Read();
            String productsJSON = JsonConvert.SerializeObject(products, Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(productsJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet]
        [Route("api/getproducts/{key}")]
        [EnableCors(origins: "http://<ip_address>:4200", headers: "*", methods: "*")]
        public HttpResponseMessage GetCategory(string key)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            ProductService productservice = new ProductService();
            List<Product> product = productservice.Read();
            int id = productservice.GetIndex(key);
            if (id != -1)
            {
                Product ct = product[id];
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
        [Route("api/postproducts")]
        [EnableCors(origins: "http://<ip_address>:4200", headers: "*", methods: "*")]
        public  HttpResponseMessage PostProducts(Object product)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                String productJSON = product.ToString();

                Product p = JsonConvert.DeserializeObject<Product>(productJSON);
                ProductService ps = new ProductService();
                if (ps.Create(p))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Producto creado\n", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("Error al crear producto", Encoding.UTF8, "application/json");
                }
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                response.Content = new StringContent("Error!!!", Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpPut]
        [Route("api/updateproduct/{key}")]
        [EnableCors(origins: "http://<ip_address>:4200", headers: "*", methods: "*")]
        public HttpResponseMessage UpdateProduct(Object producto, string key)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                Product p = JsonConvert.DeserializeObject<Product>(producto.ToString());
                ProductService ps = new ProductService();
                if (ps.Update(key, p))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("Producto actualizado", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("Error al actualizar producto", Encoding.UTF8, "application/json");
                }
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                response.Content = new StringContent("Error!!!", Encoding.UTF8, "application/json");
            }
            return response;
        }

        [HttpDelete]
        [Route("api/deleteproduct/{id}")]
        [EnableCors(origins: "http://<ip_address>:4200", headers: "*", methods: "*")]
        public HttpResponseMessage DeleteProduct(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                ProductService ps = new ProductService();
                if (ps.Delete(id))
                {
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent("producto eliminado", Encoding.UTF8, "application/json");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    response.Content = new StringContent("Error al eliminar producto", Encoding.UTF8, "application/json");
                }
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                response.Content = new StringContent("Error!!!", Encoding.UTF8, "application/json");
            }
            return response;
        }
    }
}