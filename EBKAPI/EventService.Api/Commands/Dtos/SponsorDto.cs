using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Commands.Dtos
{
   public class SponsorDto
    {
        public string EventCode { get;  set; }
        public string Image { get;  set; }
        public string Name { get;  set; }
        public string EmailAddress { get;  set; }
        public string WebSiteLink { get;  set; }
        public string CellContacts { get;  set; }
        public string MoreInfo { get;  set; }
    }
}
