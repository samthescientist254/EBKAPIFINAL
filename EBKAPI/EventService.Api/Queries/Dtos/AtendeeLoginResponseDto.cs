using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Queries.Dtos
{
    public class AtendeeLoginResponseDto
    {
        public IEnumerable<EventDto> UpcomingEvents { get; set; }
        public IEnumerable<EventDto> MySubscribedEvents { get; set; }
        public IEnumerable<EventDto> MySubscribedPastEvents { get; set; }
        public IEnumerable<AtendeeDto> MyProfile { get; set; }
    }
}
