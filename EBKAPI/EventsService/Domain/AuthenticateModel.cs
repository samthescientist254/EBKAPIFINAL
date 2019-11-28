using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
    public class AuthenticateModel
    {
        public string Email { get; set; }
        public string EventCode { get; set; }
    }
}
