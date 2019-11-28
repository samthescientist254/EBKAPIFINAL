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
    public class SponsorsController : ControllerBase
    {
        private readonly IMediator mediator;
        public SponsorsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/Sponsors
        [HttpGet]
        public async Task<IActionResult> GetAllq([FromBody] FindAllSponsorsQuery request)
        {
            var result = await mediator.Send(request);
            return new JsonResult(result);
        }

        // GET: api/Sponsors/5
        [HttpGet("{sponsorid}"/*, Name = "Get"*/)]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {

            var result = await mediator.Send(new FindAllSponsorsByIdQuerry { SponsorId = id });

            return new JsonResult(result);
        }

        // POST: api/Sponsors
        [HttpPost]
        public async Task<IActionResult> GetAll([FromBody] FindAllSponsorsQuery request)
        {
            var result = await mediator.Send(request);
            return new JsonResult(result);
        }

        // PUT: api/Sponsors/5
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
