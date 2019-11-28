using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Commands.Dtos
{
    public class ActivateLiveSessionCommand :IRequest<ActivateLiveSessionResult>
    {
       public string AttendanceCode { get; set; }
     }
}


