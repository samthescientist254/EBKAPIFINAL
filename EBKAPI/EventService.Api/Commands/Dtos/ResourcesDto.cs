using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Commands.Dtos
{
    public class ResourcesDto
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string File { get; set; }
        public Guid SessionId { get; set; }
        public string Status { get; set; }
    }
}
