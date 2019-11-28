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
    public class UpdateMemberHandler : IRequestHandler<UpdateMemberCommand, UpdateMemberResult>
    {
        private readonly IMemberRepository member;
        public UpdateMemberHandler(IMemberRepository memberRepository)
        {
            this.member = memberRepository;
        }
        public async Task<UpdateMemberResult> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var status =await member.Update(request.member);
            return new UpdateMemberResult
            {
                Updated = status
            };

        }
    }
}
