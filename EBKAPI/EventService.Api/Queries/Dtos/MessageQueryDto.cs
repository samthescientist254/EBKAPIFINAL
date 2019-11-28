using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Queries.Dtos
{
    public class MessageQueryDto
    {
        public string MessageToken { get; set; }
        public Guid TokenId { get; set; }
    }
}
