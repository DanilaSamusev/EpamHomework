using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Authentication;
using Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FinanceAssistant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private List<User> users = new List<User>
        {
            new User {Name = "admin", Password = "12345", Role = "admin"},
            new User {Name = "user", Password = "55555", Role = "user"}
        };

        [HttpPost("token")]
        public IActionResult Token([FromQuery]string username)
        {
            var identity = GetIdentity(username);
            if (identity == null)
            {
                return BadRequest(new {errorText = "Invalid username or password."});
            }

            var time = DateTime.UtcNow;
           
            var jwt = new JwtSecurityToken(
                issuer: AuthenticationOptions.Issuer,
                audience: AuthenticationOptions.Audience,
                notBefore: time,
                claims: identity.Claims,
                expires: time.Add(TimeSpan.FromMinutes(AuthenticationOptions.Lifetime)),
                signingCredentials: new SigningCredentials(AuthenticationOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Ok(response);
        }

        private ClaimsIdentity GetIdentity(string username)
        {
            var user = users.FirstOrDefault(x => x.Name == username);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                };

                var claimsIdentity = new ClaimsIdentity(claims, "Token",
                    ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }
    }
}