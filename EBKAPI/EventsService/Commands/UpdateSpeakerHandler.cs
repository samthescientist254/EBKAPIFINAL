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
    public class UpdateSpeakerHandler : IRequestHandler<UpdateSpeakerCommand, UpdateSpeakerResult>
    {
        private readonly ISpeakerRepository speaker;
        public UpdateSpeakerHandler(ISpeakerRepository speakerRepository)
        {
            this.speaker = speakerRepository;
        }
        public async Task<UpdateSpeakerResult> Handle(UpdateSpeakerCommand request, CancellationToken cancellationToken)
        {
            var status = await speaker.Update(request.speaker);
            return new UpdateSpeakerResult
            {
                Updated = status
            };
        }
    }
}
