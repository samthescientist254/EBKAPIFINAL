using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Queries.Dtos
{
    public class EventSessionQueryDto
    {
        public Guid Id { get; set; }
        public DateTime? Day { get; set; }
        public string Name { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string Venue { get; set; }
        public string Status { get; set; }
    }
}
