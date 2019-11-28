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
    public class QuestionsController : ControllerBase
    {
        private readonly IMediator mediator;
        public QuestionsController(IMediator mediator)
        {

            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        // GET: api/Questions
        [HttpGet("{code}")]
        public IEnumerable<string> Getall()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Questions/5
        [HttpGet("{id}", Name = "Get5765")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Questions
        [HttpPost]
        public async Task<ActionResult> PostQuestion([FromBody] PostQuestionCommand request)
        {
            var result = await mediator.Send(request);
            return new JsonResult(result);
        }

        // PUT: api/Questions/5
        [HttpPut]
        public async Task<ActionResult> AnswerQuestion([FromBody] AnswerQuestionCommand request)
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
