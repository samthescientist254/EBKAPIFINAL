
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Commands.Dtos
{
   public class AtendeeDraftDto
    {
        public Guid AttendanceCode { get;  set; }
        public DateTime? RegistrationDate { get;  set; }
        public string EventCode { get;  set; }
        public string EbKRegNumber { get; set; }
    }
}
