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
    public class ViewUnansweredQuestionsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ViewUnansweredQuestionsController(IMediator mediator)
        {

            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        // GET: api/ViewUnansweredQuestions
        [HttpGet("{code}")]
        public IEnumerable<string> Getquestions()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ViewUnansweredQuestions/5
        [HttpGet("{id}", Name = "Get777")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ViewUnansweredQuestions
        [HttpPost]
        public async Task<ActionResult> ViewQuestion([FromBody] FindAllUnasweredSessionQuestionsQuery request)
        {
            var result = await mediator.Send(request);
            return new JsonResult(result);
        }

        // PUT: api/ViewUnansweredQuestions/5
        [HttpPut]
        public async Task<ActionResult> ViewMyQuestions([FromBody] FindMyQuestionsQuerry request)
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
