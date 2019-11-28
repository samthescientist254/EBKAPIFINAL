using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Commands.Dtos
{
    public class MessageDto
    {
        public Guid Id { get; set; }
        public DateTime? TimeSent { get;  set; }
        public bool? DeleteForMe { get;  set; }
        public bool? DeleteForYou { get;  set; }
        public bool? DeleteForAll { get;  set; }
        public bool? Sent { get;  set; }
        public string SenderId { get;  set; }
        public string Message { get;  set; }
    }
}
