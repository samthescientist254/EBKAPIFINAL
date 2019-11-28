using EventService.Api.Queries.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Queries
{
    public class FindIndividualSpeakerSessionsQuery : IRequest<IEnumerable<EventSessionQueryDto>>
    {
        public Guid SpeakerId { get; set; }
    }

}
