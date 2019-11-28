using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsService.Domain
{
    public sealed class Event
    {
        public Guid Id { get; private set; }
        public string Name { get;private set; }
        public string Title { get;private set; }
        public string Description { get;private set; }
        public string Code { get;private set; }
        public EventStatus Status { get; set; }
        public string Image { get; private set; }
        public string Location { get; private set; }
       // public decimal GpsLat { get; private set; }
       // public decimal GpsLong { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
           
        public IList<Speakers> Speakers { get; private set; }
        public IList<Sponsors> Sporsors { get; private set; }
        public IList<Atendee> Atendees { get; private set; }

        public Event() { }

        private Event(string code,string name,string image,string description,string location,string title)
        {
            Id = Guid.NewGuid();
            Speakers = new List<Speakers>();
            Location = location;
            Sporsors = new List<Sponsors>();
            Name = name;
            Description = description;
            Code = code;
            Status = EventStatus.Draft;
            Image = image;
            Title = title;
        }

        public static Event CreateDraftEvent(string name, string image,string description,string venueId, string title)
        {
            int length = 6;
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append("0123456789"[rnd.Next("9876543210".Length)]);
            }
            string EventCode = res.ToString();
            return new Event(EventCode,name, image, description,venueId,title);
        }

        public void AddSpeaker(string firstName, string lastName, string email, string phoneNumber, string originCompany, string moreInfo, string eventCode, string image, string title)
        {
            Speakers.Add(new Speakers(firstName, lastName, email, phoneNumber, originCompany, moreInfo, eventCode, image, title));

        }
        public void AddSponsor(string eventCode, string name, string email, string contacts, string moreInfo, string image, string webSiteLink)
        {
            Sporsors.Add(new Sponsors(eventCode, name, email, contacts, moreInfo, image, webSiteLink));
        }

        private void EnsureEventIsDraft()
        {
            if (Status != EventStatus.Draft)
            {
                throw new ApplicationException("Only Draft Events can be modified and activated");
            }
        }
        public string GenerateEventCode()
        {
            int length = 6;
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append("0123456789"[rnd.Next("9876543210".Length)]);
            }
            string EventCode = res.ToString();
            return EventCode;
        }
        private void EnsureEventHasBeenExecuted()
        {
            if (Status != EventStatus.Executed)
            {
                throw new ApplicationException("Only Executed Events can be Closed");
            }
        }

        public void ActivateEvent()
        {
            EnsureEventIsDraft();
            Status = EventStatus.Active;
        }

        public void CancelEvent()
        {
            Status = EventStatus.Cancelled;
        }

        public void CloseExecutedEvent()
        {
            Status = EventStatus.Executed;
        }

    }
    public enum EventStatus
    {
        Draft,
        Active,
        Executed,
        Cancelled
    }
}