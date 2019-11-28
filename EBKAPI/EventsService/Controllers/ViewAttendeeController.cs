using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventService.Api.Queries.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewAttendeeController : Controller
    {
        private readonly IMediator mediator;


        public ViewAttendeeController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> GetAll([FromBody] FindAllAtendeesQuery request)
        {
            var result = await mediator.Send(request);
            return new JsonResult(result);
        }
    }
}