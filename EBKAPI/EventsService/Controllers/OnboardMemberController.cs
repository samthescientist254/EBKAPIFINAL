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
    public class OnboardMemberController : ControllerBase
    {
        private readonly IMediator mediator;
        public OnboardMemberController(IMediator mediator)
        {

            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        // GET: api/OnboardMember
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/OnboardMember/5
        [HttpGet("{id}", Name = "Get423")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/OnboardMember
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/OnboardMember/5
        [HttpPut]
        public async Task<ActionResult> OnBoardMember([FromBody] RegisterMemberCommand request)
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
