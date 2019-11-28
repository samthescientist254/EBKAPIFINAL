using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Queries.Dtos
{
   public class FindAllSpeakersQuery: IRequest<IEnumerable<SpeakerQueryDto>>
    {
        public Guid EventId { get; set; }
    }
}
