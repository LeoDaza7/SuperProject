using Newtonsoft.Json;
using SuperProject;
using SuperProject.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace WAPI.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("api/getproducts")]
        public HttpResponseMessage GetProducts()
        {
            ProductService ps = new ProductService();
            List<Product> products = ps.Read();
            String productsJSON = JsonConvert.SerializeObject(products, Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(productsJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpPost]
        [Route("api/postproducts")]
        public  HttpResponseMessage PostProducts(Object product)
        {
            String productJSON = product.ToString();
            
            Product p = JsonConvert.DeserializeObject<Product>(productJSON);            
            ProductService ps = new ProductService();
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            if(ps.Create(p))
            {
                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent("Producto creado\n" + lista(ps.Read()), Encoding.UTF8, "application/json");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                response.Content = new StringContent("Error al crear producto", Encoding.UTF8, "application/json");
            }
            return response;
        }

        private string lista(List<Product> ps)
        {
            string aux = "";
            foreach(Product p in ps)
            {
                aux += p.toString();
            }
            return aux;
        }
    }
}