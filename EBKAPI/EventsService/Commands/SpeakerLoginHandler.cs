
using AuthService.Api.Domain;
using EventService.Api.Commands.Dtos;
using EventsService.Domain;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AuthService.Api.Commands
{
    public class SpeakerLoginHandler : IRequestHandler<SpeakerLoginCommand, SpeakerLoginDto>
    {
        private readonly IUserService userService;
        private readonly AppSettings _appSettings;
        public SpeakerLoginHandler(IUserService userService,IOptions<AppSettings> appsettings)
        {
            this.userService = userService;
            _appSettings = appsettings.Value;
        }
        public async Task<SpeakerLoginDto> Handle(SpeakerLoginCommand request, CancellationToken cancellationToken)
        {
            var result = await userService.Authenticate(request.loginCredentials);
            if (result == null) return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, result.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return result != null ? new SpeakerLoginDto
            {
               FirstName=result.FirstName,
               LastName=result.LastName,
               Email=result.Email,
               EventCode=result.EventCode,
               Image=result.Image,
               MoreInfo=result.MoreInfo,
               OriginCompany=result.OriginCompany,
               PhoneNumber=result.PhoneNumber,
               SpeakerId=result.Id,
               Title=result.Title,
               JwtAuthToken=tokenString 
            } : null;
           
        }
    }
}
