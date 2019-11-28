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
    public class RegisterMemberHandler : IRequestHandler<RegisterMemberCommand, RegisterMemberResult>
    {
        private readonly IMemberRepository member;
        public RegisterMemberHandler(IMemberRepository memberRepository)
        {
            this.member = memberRepository;
        }

        public async Task<RegisterMemberResult> Handle(RegisterMemberCommand request, CancellationToken cancellationToken)
        {
            var status = await member.Onboard(request.member);
            return new RegisterMemberResult
            {
                Registered = status
            };
        }
    }
 }
