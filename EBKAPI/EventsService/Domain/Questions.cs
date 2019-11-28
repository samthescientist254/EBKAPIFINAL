using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
    public sealed class Questions
    {
        public Guid Id { get; set; }
        public string QuestionBody { get;  set; }
        public DateTime? PostingDate { get;  set; }
        public DateTime? ResponseDate { get;  set; }
        public string ResponseBody { get;  set; }
        public Status Status { get;  set; }
        //public Atendee Poster { get;  set; }
        public Guid PosterId { get;  set; }
        public Guid RespondentId { get;  set; }
        public Guid SessionId { get;  set; }
        public Guid EventId { get;  set; }
        //public EventSessions? Session { get;  set; }
        public Questions() { }
        private void EnsureQuestionIsNotYetAnswered()
        {
            if ((string.IsNullOrWhiteSpace(QuestionBody)))
            {
                throw new AppException("Only New Questions with body can be posted");
            }
        }
        public Questions(string body, Guid posterId, Guid sessionId,Guid eventId)
        {
            QuestionBody = body;
            EnsureQuestionIsNotYetAnswered();
            Id = Guid.NewGuid();
            PosterId = posterId;
            Status = Status.Posted;
            PostingDate = DateTime.Now;
            SessionId = sessionId;
            EventId = eventId;

        }
        public static Questions AddNewQuestion(string body, Guid posterId, Guid sessionId,Guid eventId)
        {
            return new Questions(body, posterId, sessionId,eventId);
        }
    }
        public  enum Status
        {
            Posted,
            Approved,
            Responded
        }

   

}

