using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Domain
{
    public class AuthService
    {
        private readonly IAppUser User;
        private readonly AppSettings AppSettings;

        public AuthService(IAppUser user,IOptions<AppSettings> appSettings)
        {
            User = user;
            AppSettings = appSettings.Value;
        }

        public string Authenticate(string login, string pwd)
        {
            var user = User.FindByLogin(login);
            if (user == null) return null;
            if (!user.PasswordMatches(pwd)) return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AppSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
               {
                   new Claim("sub", user.Login),
                   new Claim(ClaimTypes.Name, user.Login),
                   new Claim(ClaimTypes.Role, "ADMIN"),
                   new Claim(ClaimTypes.Role, "ATENDEE"),
                   new Claim(ClaimTypes.Role, "SPEAKER"),
                   new Claim("userType", "ADMIN")
               }),
                Expires = DateTime.UtcNow.AddDays(7),
             SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public AppUsers UserFromLogin(string login)
        {
            return User.FindByLogin(login);
        }
    }
}
