using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventService.Api.Commands;
using EventService.Api.Queries.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakerProfileController : ControllerBase
    {
        private readonly IMediator mediator;
        public SpeakerProfileController(IMediator mediator)
        {

            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        // GET: api/SpeakerProfile
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SpeakerProfile/5
        [HttpGet("{id}", Name = "Get7")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SpeakerProfile
        [HttpPost]
        public async Task<ActionResult> GetMyProfile([FromBody] FindAllSpeakersbyIdQuery request)
        {
            var result = await mediator.Send(request);
            return new JsonResult(result);
        }

        // PUT: api/SpeakerProfile/5
        [HttpPut]
        public async Task<ActionResult> EditMyProfile([FromBody] UpdateSpeakerCommand request)
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
