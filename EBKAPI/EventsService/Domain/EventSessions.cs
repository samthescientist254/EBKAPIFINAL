using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
    public class EventSessions
    {
        public Guid Id { get; set; }
        public DateTime? Day { get;private set; }
        public string Name { get;private set; }
        public Guid SpeakerId { get; set; }
        public TimeSpan? StartTime { get;private set; }
        public TimeSpan? EndTime { get;private set; }
        public string Venue { get;private set; }
        public string EventCode { get;private set; }
        public SessionStatus Status { get;private set; }
        public Event Event { get;private set; }
        public EventSessions() { }
        public EventSessions(string eventCode,string name,TimeSpan? startTime,TimeSpan? endTime,string venue,Guid speakerId,DateTime? day) {
            Id = Guid.NewGuid();
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            Venue = venue;
            SpeakerId = speakerId;
            EventCode = eventCode;
            Day = day;
            Status = SessionStatus.Created;
        }
        public EventSessions CreateSession(string eventCode,string name, TimeSpan? startTime, TimeSpan? endTime, string venue, Guid speakerId,DateTime? day) {

            return new EventSessions(eventCode,name, startTime, endTime, venue,speakerId,day);
        }
        //private void EnsureSessionIsWithinEventDays(DateTime? sessionDay)
        //{
        //    if (DayChecker != EventDays.da)
        //    {
        //        throw new ApplicationException("Only Draft Events can be modified and activated");
        //    }
        //}
    }
   
    public enum SessionStatus
    {
        Created,
        Live,
        Ended,
        Paused,
        Abandoned
    }
    public class EventDays
    {
        public Guid Id { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public Event Event { get; private set; }
        public EventDays() { }
        public EventDays(DateTime? sDate, DateTime? eDate)
        {
            Id = Guid.NewGuid();
            StartDate = sDate;
            EndDate = eDate;
        }

        public EventDays AddDay(DateTime? sDate, DateTime? eDate)
        {
            return new EventDays(sDate, eDate);
        }

    }
}
