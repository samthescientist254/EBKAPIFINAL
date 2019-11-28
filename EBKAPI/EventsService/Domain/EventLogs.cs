using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
    public class EventLogs
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public string Time { get; set; }
        public EventLogs() { }
    }
}
