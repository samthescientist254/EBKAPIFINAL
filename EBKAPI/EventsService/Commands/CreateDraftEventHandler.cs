using EventService.Api.Commands;
using EventsService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EventsService.Commands
{
    public class CreateDraftEventHandler:IRequestHandler<CreateEventDraftCommand, CreateEventDraftResult>
    {
        private readonly IEventRepository Events;
        public CreateDraftEventHandler(IEventRepository @event)
        {
            Events = @event;
        }
        public async Task<CreateEventDraftResult> Handle(CreateEventDraftCommand request, CancellationToken cancellationToken)
        {
            var draft = Event.CreateDraftEvent(
                request.eventDraft.Name,
                request.eventDraft.Image,
                request.eventDraft.Description,
                request.eventDraft.Location,
                request.eventDraft.Title
                );
            foreach(var speaker in request.eventDraft.Speakers)
            {
                draft.AddSpeaker(speaker.FirstName, speaker.LastName, speaker.Email, speaker.PhoneNumber, speaker.OriginCompany, speaker.MoreInfo, speaker.EventCode, speaker.Image, speaker.Title);
            }
            foreach(var sponsor in request.eventDraft.Sporsors)
            {
                draft.AddSponsor(sponsor.EventCode, sponsor.Name, sponsor.EmailAddress, sponsor.CellContacts, sponsor.MoreInfo, sponsor.Image, sponsor.WebSiteLink);
            }

            await Events.Add(draft);

            return new CreateEventDraftResult
            {
                Id = draft.Id
            };
        }
    }
}
