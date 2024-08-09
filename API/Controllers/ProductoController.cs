using API.Configuration;
using API.Handlers;
using API.Managers;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("productos")]
    public class ProductoController
    {
        private ProductoHandler handler = new ProductoHandler();
        [HttpGet]
        public async Task<ActionResult<List<ProductoModel>>> Get()
        {
            return await handler.GetProducts();
        }
        [HttpPost("create")]
        public async Task Post([FromBody] ProductoModel product)
        {
            await handler.InsertProduct(product);
        }
        [HttpPut("update/{id}")]
        public async Task Put(int id, [FromBody] ProductoModel product)
        {
            product.Id = id;
            await handler.UpdateProduct(product);
        }
        [HttpDelete("delete/{id}")]
        public async Task Delete(int id, [FromBody] ProductoModel product)
        {
            product.Id = id;
            await handler.DeleteProduct(product);
        }
    }
}
