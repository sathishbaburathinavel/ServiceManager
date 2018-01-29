using Addon.ServiceManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Addon.ServiceManager.Controllers
{
    public class ProductController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };
        [AllowAnonymous]
        [HttpGet]
        [Route("api/products")]
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }


        [Authorize]
        [HttpGet]
        public IHttpActionResult GetByProductID(int id)
        {
            var productEnum = products.FirstOrDefault((p) => p.Id == id);
            if (productEnum == null)
                return NotFound();

            return Ok(productEnum);
        }
    }
}
