using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventService.Api.Queries;
using EventService.Api.Queries.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly IMediator mediator;
        public SessionsController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        // GET: api/Sessions
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Sessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSessionById([FromRoute]Guid sessionid)
        {
            var result = await mediator.Send(new FindSessionByIdQuery { SessionId = sessionid });

            return new JsonResult(result);
        }

        // POST: api/Sessions
        [HttpPost]
        public async Task<IActionResult> GetAll([FromBody] FindAllSessionsQuerry request)
        {
            var result = await mediator.Send(request);
            return new JsonResult(result);
        }

        // PUT: api/Sessions/5
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
