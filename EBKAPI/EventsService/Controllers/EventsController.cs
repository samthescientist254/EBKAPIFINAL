using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using EventService.Api.Queries;
using EventService.Api.Commands;
using EventService.Api.Commands.Dtos;

namespace EventsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator mediator;
        public EventsController(IMediator mediator) {

            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await mediator.Send(new FindAllEventsQuerry());
            return new JsonResult(result);
        }
        // GET: api/Events/{code}
        [HttpGet("{code}")]
        public async Task<ActionResult> GetByCode([FromRoute]string code)
        {
            //var result = await mediator.Send(new FindEventByCodeQuerry { EventCode = code });
            return null;
            //return new JsonResult(result);
        }

        // POST: api/Events
        [HttpPost]
        public async Task<ActionResult> GetByCode(FindEventByCodeQuerry request)
        {
            var result = await mediator.Send(request);

            return new JsonResult(result);
        }
        //public async Task<ActionResult> PostDraft([FromBody] CreateEventDraftCommand request)
        //{
        //    var result = await mediator.Send(request);
        //    return new JsonResult(result);
        //}
        //// POST: api/Events/activate
        //[HttpPost("api/Events/activate")]
        //public async Task<ActionResult> Activate([FromBody] ActivateEventCommand request)
        //{
        //    var result = await mediator.Send(request);
        //    return new JsonResult(result);
        //}

        // POST: api/Events/cancel
        [HttpPost("/cancel")]
        public async Task<ActionResult> Cancel([FromBody] CancelEventCommand request)
        {
            var result = await mediator.Send(request);
            return new JsonResult(result);
        }
        // PUT: api/Events/5
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
