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
    public class FetchMessageTokensController : ControllerBase
    {
        private readonly IMediator mediator;
        public FetchMessageTokensController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        // GET: api/FetchMessageTokens
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FetchMessageTokens/5
        [HttpGet("{id}", Name = "Geterer")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FetchMessageTokens
        [HttpPost]
        public async Task<IActionResult> Messages([FromBody] FindMessagesByRegNumberQuery request)
        {
            var result = await mediator.Send(request);
            if (result == null)
                return BadRequest(new { message = "Message Token is Invalid" });
            return new JsonResult(result);
        }

        // PUT: api/FetchMessageTokens/5
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
