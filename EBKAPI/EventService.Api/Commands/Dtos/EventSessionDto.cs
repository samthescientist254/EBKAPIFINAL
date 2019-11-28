using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Commands.Dtos
{
    public class EventSessionDto
    {
        public Guid Id { get;  set; }
        public DateTime? Day { get;  set; }
        public string Name { get;  set; }
        public string SpeakerId { get;  set; }
        public TimeSpan StartTime { get;  set; }
        public TimeSpan EndTime { get;  set; }
        public string Venue { get;  set; }
        public string EventCode { get;  set; }
        public int Status { get;  set; }
    }
}
