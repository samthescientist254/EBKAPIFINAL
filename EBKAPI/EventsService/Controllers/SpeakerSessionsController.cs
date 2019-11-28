using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventService.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakerSessionsController : ControllerBase
    {
        private readonly IMediator mediator;
        public SpeakerSessionsController(IMediator mediator)
        {

            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        // GET: api/SpeakerSessions
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SpeakerSessions/5
        [HttpGet("{id}", Name = "Get4")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SpeakerSessions
        [HttpPost]
        public async Task<ActionResult> GetSessions([FromBody] FindIndividualSpeakerSessionsQuery request)
        {
            var result = await mediator.Send(request);
            return new JsonResult(result);
        }

        // PUT: api/SpeakerSessions/5
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
