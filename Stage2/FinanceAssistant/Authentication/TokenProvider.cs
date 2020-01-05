using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Contracts.RepositoryContracts;
using Microsoft.IdentityModel.Tokens;

namespace Authentication
{
    public class TokenProvider
    {
        private readonly IUserRepository _userRepository;

        public TokenProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string ProvideToken(string password)
        {
            var identity = GetIdentity(password);

            if (identity == null)
            {
                return null;
            }

            var time = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: AuthenticationOptions.Issuer,
                audience: AuthenticationOptions.Audience,
                notBefore: time,
                claims: identity.Claims,
                expires: time.Add(TimeSpan.FromMinutes(AuthenticationOptions.Lifetime)),
                signingCredentials: new SigningCredentials(AuthenticationOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));
            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

            return encodedToken;
        }

        private ClaimsIdentity GetIdentity(string password)
        {
            var user = _userRepository.GetByPassword(password);

            if (user == null)
            {
                return null;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                //new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Token",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            
            return claimsIdentity;
        }
    }
}