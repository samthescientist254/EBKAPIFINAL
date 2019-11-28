using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Queries.Dtos
{
    public class FindAllSpeakersbyIdQuery : IRequest<SpeakerQueryDto>
    {
        public Guid SpeakerId { get; set; }
    }

}
