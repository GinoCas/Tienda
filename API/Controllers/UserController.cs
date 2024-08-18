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
            UserModel? user_found = await handler.GetUserByEmail(user.Email);
            if (user_found == null || user_found.Password != user.Password)
            {
                return Unauthorized();
            }
			APIResponse<UserModel> response = new APIResponse<UserModel>
			{
				Data = [new(user_found.Id, user_found.Name, user_found.Surname, user_found.Email)],
				Errors = []
			};
            return Ok(response);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserModel user)
        {
            UserModel? user_found = await handler.GetUserByEmail(user.Email);
            if (user_found != null)
            {
                return BadRequest(new { message = "Usuario ya existente."});
            }
			if(await handler.PostUser(user) > 0)
			{
				APIResponse<UserModel> response = new APIResponse<UserModel>
				{
					Data = [new(user.Id, user.Name, user.Surname, user.Email)],
					Errors = []
				};
				return Ok(response);
			}
			return StatusCode(500, new { message = "Error al crear el usuario."});
        }
    }
}
