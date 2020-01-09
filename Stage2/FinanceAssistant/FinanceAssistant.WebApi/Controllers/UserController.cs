using Contracts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAssistant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetUser(int id)
        {
            var claims = HttpContext.Request.Query["claims"];

            return Ok();
        }

        [HttpPut]
        public IActionResult AddUser([FromBody]User user)
        {
            return Ok();
        }
    }
}