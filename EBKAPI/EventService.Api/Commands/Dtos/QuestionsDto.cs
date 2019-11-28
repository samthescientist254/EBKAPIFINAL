using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Commands.Dtos
{
    public class QuestionsDto
    {
        public Guid Id { get; set; }
        public string QuestionBody { get; set; }
        public DateTime? PostingDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public string ResponseBody { get; set; }
        public string Status { get; set; }
        public Guid SessionId { get; set; }
        public Guid PosterId { get; set; }
        public Guid RespondentId { get; set; }
        public Guid EventId { get; set; }
    }
}
