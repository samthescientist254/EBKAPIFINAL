using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Commands.Dtos
{
    public class EventDraftDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Location { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public IList<SpeakerDto> Speakers { get;  set; }
        public IList<SponsorDto> Sporsors { get;  set; }
    }
}
