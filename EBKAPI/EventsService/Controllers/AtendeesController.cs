using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventService.Api.Commands;
using EventService.Api.Commands.Dtos;
using EventService.Api.Queries.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendeesController : ControllerBase
    {
        private readonly IMediator mediator;
        public AtendeesController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        // GET: api/Atendees
        [HttpGet]
        public async Task<IActionResult> GetAll([FromBody] FindAllAtendeesQuery request)
        {
            var result = await mediator.Send(request);
            return new JsonResult(result);
        }

        // GET: api/Atendees/5
        [HttpGet("{code}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Atendees
        [HttpPost]
        public async Task<IActionResult> SubscibeToEvent([FromBody] SubscribeToEventCommand request)
        {
            var result = await mediator.Send(request);
            return new JsonResult(result);
        }

        // PUT: api/Atendees/
        [HttpPut]
        public async Task<IActionResult> RemoteToLiveSession([FromBody] ActivateLiveSessionCommand request)
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
