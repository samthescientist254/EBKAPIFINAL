using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Commands.Dtos
{
    public class AuthDto
    {
        public string Email { get; set; }
        public string EventCode { get; set; }
    }
}
