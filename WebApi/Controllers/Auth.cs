using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class Auth : ControllerBase
    {
        [HttpPost]
        public IActionResult Auth(string username, string password) {
            if (username == "Gustavo" && password == "123456")                  // Testando parametros de lógica.
            {
                var token = TokenServices.GenerateToken(new model.Employee());  // Token gerada.
                return Ok(token);
            }
            return BadRequest();
        }
    }
}
