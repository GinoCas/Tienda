using API.Handlers;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UserController
    {
        private UserHandler handler = new UserHandler();
        [HttpPost("login")]
        public async Task<int> Login([FromBody] UserModel user)
        {
            UserModel? user_found = await handler.GetUser(user.Name);
            if (user_found == null || user_found.Password != user.Password)
            {
                Console.WriteLine("Usuario o contraseña incorrecta.");
                return 0;
            }
            Console.WriteLine("Bienvenido!");
            return 1;
        }
        [HttpPost("register")]
        public async Task<int> Register([FromBody] UserModel user)
        {
            UserModel? user_found = await handler.GetUser(user.Name);
            if (user_found != null)
            {
                Console.WriteLine("Usuario ya existente.");
                return 0;
            }
            Console.WriteLine("Usuario creado con exito.");
            return await handler.PostUser(new UserModel(user.Name, user.Password));
        }
        /*
        [HttpPost("register")]
        public async Task Put(int id, [FromBody] ProductModel product)
        {
            product.Id = id;
            await handler.UpdateProduct(product);
        }
        [HttpDelete("delete/{id}")]
        public async Task Delete(int id, [FromBody] ProductModel product)
        {
            product.Id = id;
            await handler.DeleteProduct(product);
        }
        */
    }
}
