using EventService.Api.Commands.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Commands
{
   public class UpdateMemberCommand:IRequest<UpdateMemberResult>
    {
        public MemberDto member { get; set; }
    }
}
