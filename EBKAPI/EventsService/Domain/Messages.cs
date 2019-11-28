using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
    public class Messages
    {
        public Guid Id { get;private set; }
        public DateTime? TimeSent { get;private set; }
        public bool? DeleteForMe { get;private set; }
        public bool? DeleteForYou { get;private set; }
        public bool? DeleteForAll { get;private set; }
        public bool? Sent { get;private set; }
        public string MemberId { get; set; }
        public Members Members { get;  set; }
        public string Message { get;  set; }
        public Messages() { }
        public Messages(bool? deleteForMe, bool? deleteForYou, bool? deleteForAll,string message,string senderId) {
            MemberId = senderId;
            VerifyRecipientInput();
            Id = Guid.NewGuid();
            DeleteForAll = deleteForAll;
            DeleteForMe = deleteForMe;
            DeleteForYou = deleteForYou;
            Message = message;
            Sent = true;
            TimeSent = DateTime.Now;
        }

        public static Messages SendMessage(bool? deleteForMe, bool? deleteForYou, bool? deleteForAll, string message, string senderid)
        {
            return new Messages(deleteForMe, deleteForYou, deleteForAll, message, senderid);
        }

        public void VerifyRecipientInput()
        {
            if (string.IsNullOrWhiteSpace(MemberId))
            {
                throw new ApplicationException("Sender address cannot be null");
            }
        }
    }
}
