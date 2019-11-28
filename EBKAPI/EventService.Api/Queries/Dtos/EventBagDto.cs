using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Queries.Dtos
{
    public class EventBagDto
    {
        public Guid Id { get;  set; }
        public string FileName { get;  set; }
        public string FileLink { get;  set; }
        public string Description { get;  set; }
        public string EventName { get;  set; }
    }
}
