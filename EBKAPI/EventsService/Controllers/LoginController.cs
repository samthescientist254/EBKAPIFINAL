using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthService.Api.Commands;
using EventService.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EventsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator mediator;
        public LoginController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        // GET: api/Login
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        [HttpGet("{id}", Name = "Gettr")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginSpeaker([FromBody] SpeakerLoginCommand request)
        {
            var result = await mediator.Send(request);
            if (result == null)
                return BadRequest(new { message = "username or password is incorrect" });
            var tokenHandler = new JwtSecurityTokenHandler();
           
            return new JsonResult(result);
        }

        // PUT: api/Login/5
        [HttpPut]
        public async Task<ActionResult> ViewMySessions([FromBody] FindIndividualSpeakerSessionsQuery request)
        {
            var result = await mediator.Send(request);
            return new JsonResult(result);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
