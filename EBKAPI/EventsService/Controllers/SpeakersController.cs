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
    public class SpeakersController : ControllerBase
    {
        private readonly IMediator mediator;
        public SpeakersController(IMediator mediator)
        {

            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));               
        }
        // GET: api/Speakers
        [HttpGet]
        public async Task<ActionResult> GetAllt([FromBody] FindAllSpeakersQuery request)
        {
            var result = await mediator.Send(request/*new FindAllSpeakersQuery { EventCode = EventCode }*/);
            return new JsonResult(result);
        }

        // GET: api/Speakers/{speakerid}
        [HttpGet("{speakerid}")]
      
        public async Task<ActionResult> GetById([FromRoute]Guid id)
        {
            var result = await mediator.Send(new FindAllSpeakersbyIdQuery { SpeakerId = id });

            return new JsonResult(result);
        }
        // POST: api/Speakers
        [HttpPost]
        public async Task<ActionResult> GetAll([FromBody] FindAllSpeakersQuery request)
        {
            var result = await mediator.Send(request);
            return new JsonResult(result);
        }

        // PUT: api/Speakers/5
        [HttpPut]
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
