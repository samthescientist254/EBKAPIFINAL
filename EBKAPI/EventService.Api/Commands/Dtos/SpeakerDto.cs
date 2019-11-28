using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Commands.Dtos
{
    public class SpeakerDto
    {
        public string FirstName { get;  set; }
        public string Image { get;  set; }
        public string LastName { get;  set; }
        public string Email { get;  set; }
        public string PhoneNumber { get;  set; }
        public string OriginCompany { get;  set; }
        public string Title { get;  set; }
        public string MoreInfo { get;  set; }
        public string EventCode { get;  set; }
    }
}
