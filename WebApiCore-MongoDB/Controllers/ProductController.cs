using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore_MongoDB.Models;
using WebApiCore_MongoDB.Services;

namespace WebApiCore_MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

   


        [HttpGet]
        [Route("GetProducts")]
        public ActionResult<List<Product>> Get() =>
            _productService.Get();


        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        public ActionResult<Product> Get(string id)
        {
            var Product = _productService.Get(id);

            if (Product == null)
            {
                return NotFound();
            }

            return Product;
        }

        [HttpPost]
        public ActionResult<Product> Create(Product Product)
        {
            _productService.Create(Product);

            return CreatedAtRoute("GetProduct", new { id = Product.Id.ToString() }, Product);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Product ProductIn)
        {
            var Product = _productService.Get(id);

            if (Product == null)
            {
                return NotFound();
            }

            _productService.Update(id, ProductIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Product = _productService.Get(id);

            if (Product == null)
            {
                return NotFound();
            }

            _productService.Remove(Product.Id);

            return NoContent();
        }
    }
}
