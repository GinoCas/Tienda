using API.Configuration;
using API.Handlers;
using API.Managers;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("productos")]
    public class ProductController
    {
        private ProductHandler handler = new ProductHandler();
        [HttpGet]
        public async Task<ActionResult<List<ProductModel>>> Get()
        {
            return await handler.GetProducts();
        }
        [HttpPost("create")]
        public async Task CreateProduct([FromBody] ProductModel product)
        {
            await handler.PostProduct(product);
        }
        [HttpPut("update/{id}")]
        public async Task UpdateProduct(int id, [FromBody] ProductModel product)
        {
            product.Id = id;
            await handler.PostProduct(product);
        }
        [HttpDelete("delete/{id}")]
        public async Task DeleteProduct(int id, [FromBody] ProductModel product)
        {
            product.Id = id;
            await handler.DeleteProduct(product);
        }
    }
}
