using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventService.Api.Queries.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendeeLoginController : ControllerBase
    {
        private readonly IMediator mediator;
        public AtendeeLoginController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        // GET: api/AtendeeLogin
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AtendeeLogin/5
        [HttpGet("{id}", Name = "Getdfgdfg")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AtendeeLogin
        [HttpPost]
        public async Task<IActionResult> LoginAtendee([FromBody] LoginResponseDataQuery request)
        {
            var result = await mediator.Send(request);
            if (result == null)
                return BadRequest(new { message = "EbKReg or password is incorrect" });
            //var tokenHandler = new JwtSecurityTokenHandler();

            return new JsonResult(result);
        }

        // PUT: api/AtendeeLogin/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
