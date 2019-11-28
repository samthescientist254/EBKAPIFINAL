using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Queries.Dtos
{
    public class QuestionQuerryDto
    {
        public Guid Id { get;  set; }
        public string QuestionBody { get;  set; }
        public DateTime? PostingDate { get;  set; }
        public DateTime? ResponseDate { get;  set; }
        public string ResponseBody { get;  set; }
        public string Status { get;  set; }
        public Guid SessionId { get;  set; }
        public Guid PosterId { get;  set; }
        public Guid RespondentId { get;  set; }
        public string RespondentName { get;  set; }
        public string RespondentEmail { get;  set; }
        public string RespondentTelephone { get;  set; }
        public string PosterName { get;  set; }
        public string PosterEmail { get;  set; }
        public string SessionTitle { get;  set; }
        public string SessionState { get;  set; }
        public string PosterTelephone { get;  set; }
        public string PosterOrganisation { get;  set; }
    }
}
