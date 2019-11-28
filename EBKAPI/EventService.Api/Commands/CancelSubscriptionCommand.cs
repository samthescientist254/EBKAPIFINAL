﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Commands
{
    public class CancelSubscriptionCommand : IRequest<CancelSubscriptionResult>
    {
        public string AttendanceCode { get; set; }
    }
}
