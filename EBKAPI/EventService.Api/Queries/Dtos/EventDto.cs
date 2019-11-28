using EventService.Api.Commands.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Queries.Dtos
{
   public class EventDto
    {
        public string Name { get; set; }
        public Guid EventId { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Location { get;  set; }
        public DateTime? StartDate { get;  set; }
        public DateTime? EndDate { get;  set; }

        public IList<SpeakerDto> Speakers { get; set; }
        public IList<SponsorDto> Sporsors { get; set; }
    }
}
