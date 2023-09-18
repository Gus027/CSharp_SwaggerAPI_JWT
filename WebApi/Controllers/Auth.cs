using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Services;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class Auth : Controller
    {
        [HttpPost]
        public IActionResult auth(string username, string password) {
            if (username == "Gustavo" && password == "123456")
            {
                var token = TokenServices.GenerateToken(new Domain.model.Employee());
                return Ok(token);
            }
            return BadRequest();
        }
    }
}
