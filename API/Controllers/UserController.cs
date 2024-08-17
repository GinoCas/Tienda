using API.Handlers;
using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UserController : ControllerBase
    {
        private UserHandler handler = new UserHandler();
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserModel user)
        {
            UserModel? user_found = await handler.GetUser(user.Name);
            if (user_found == null || user_found.Password != user.Password)
            {
                return Unauthorized(new { message = "Usuario o contraseña incorrecta."});
            }
            return Ok(new { message = "Bienvenido" });
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserModel user)
        {
            UserModel? user_found = await handler.GetUser(user.Name);
            if (user_found != null)
            {
                return BadRequest(new { message = "Usuario ya existente."});
            }
			if(await handler.PostUser(user) > 0)
			{
				return Ok(new { message = "Usuario creado con exito." });
			}
			return StatusCode(500, new { message = "Error al crear el usuario."});
        }
    }
}
