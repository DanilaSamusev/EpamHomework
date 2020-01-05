using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Authentication
{
    public class AuthenticationOptions
    {
        public const string Issuer = "MyAuthServer"; 
        public const string Audience = "MyAuthClient"; 
        const string Key = "mysupersecret_secretkey!123";  
        public const int Lifetime = 10; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}