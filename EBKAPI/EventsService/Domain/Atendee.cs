
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsService.Domain
{
    public  class Atendee
    {
        public  Guid Id { get; set; }
        //public string AttendanceCode { get; private set; }
        public DateTime? RegistrationDate { get; private set; }
        //public string EventCode { get; private set; }
        public string EbKRegNumber { get; private set; }
        public  AttendanceStatus Status { get;  set; }
        public  Event Event { get; private set; }
        public  Members Members { get;  set; }
        public Atendee() { }
        public void CancelSubscription()
        {
            EnsureEventHasNotStarted();
            Status = AttendanceStatus.Cancelled;
        }

        public Atendee(string ebkReg,string eventId,Guid memberId)
        {
            
            Id = Guid.NewGuid();
           // AttendanceCode = attendaceCode;
            RegistrationDate = DateTime.UtcNow;
            //EventCode = eventCode;
            Status = AttendanceStatus.Subscribed;
            EbKRegNumber = ebkReg;
            Members.Id = memberId;
        }

        public static Atendee SubscribeToEvent(string eventCode,string ebkReg)
        {
            int length = 6;
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append("0123456789"[rnd.Next("9876543210".Length)]);
            }
            string atendanceCode = res.ToString();
            return null;
            //return new Atendee(atendanceCode, ebkReg,eventCode);
        }

        public void ActivateLiveSession(string sessionId)
        {
            //void method to check status of particular event session
            
        }
       
        private void EnsureEventHasNotStarted()
        {
            if ((Event.Status != EventStatus.Draft)||(Event.Status != EventStatus.Cancelled)||(Event.Status != EventStatus.Executed))
            {
                throw new ApplicationException("Only upcoming or cancelled events can allow Unsubscription");
            }
        }
        public enum AttendanceStatus
        {
            Subscribed,
            InSession,
            Cancelled,
            Attended
        }
    }
}
