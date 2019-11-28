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
    public class EventBagsController : ControllerBase
    {
        private readonly IMediator mediator;
        public EventBagsController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        // GET: api/EventBags
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EventBags/5
        [HttpGet("{id}", Name = "Getee323")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EventBags
        [HttpPost]
        public async Task<IActionResult> GetAllBags([FromBody] FindAllResourcesQuerry request)
        {
            var result = await mediator.Send(request);
            return new JsonResult(result);
        }

        // PUT: api/EventBags/5
        [HttpPut]
        public async Task<IActionResult> GetSingleBag([FromBody] FindResourceById request)
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
