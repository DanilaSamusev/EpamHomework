using Authentication;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAssistant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly TokenProvider _tokenProvider;
        
        public AccountController(TokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }
        
        [HttpPost("token")]
        public IActionResult GetToken([FromQuery]string password)
        {
            var token = _tokenProvider.ProvideToken(password);

            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Check input data!");
            }
            
            return Ok($"Bearer {token}");
        }

    }
}