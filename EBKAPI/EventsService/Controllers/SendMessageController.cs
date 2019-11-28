using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventService.Api.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly IMediator mediator;
        public SendMessageController(IMediator mediator)
        {

            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        // GET: api/SendMessage
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SendMessage/5
        [HttpGet("{id}", Name = "Geteqe")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SendMessage
        [HttpPost]
        public async Task<ActionResult> NewMessage([FromBody] SendMessageCommand request)
        {
            var result = await mediator.Send(request);
            return new JsonResult(result);
        }

        // PUT: api/SendMessage/
        [HttpPut]
        public async Task<ActionResult> UpdateMessage([FromBody] UpdateMessageCommand request)
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
