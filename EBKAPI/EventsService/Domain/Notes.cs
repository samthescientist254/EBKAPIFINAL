using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
    public class Notes
    {
        public Guid Id { get;private set; }
        public string SessionId { get;private set; }
        public string AtendeeId { get;private set; }
        public string MyNotes { get;private set; }
        public NotesStatus Status { get;private set; }

        public Notes() { }
        public Notes(string sessioId,string atendeeId,string myNotes)
        {
            Id = Guid.NewGuid();
            SessionId = sessioId;
            AtendeeId = atendeeId;
            MyNotes = myNotes;
            Status = NotesStatus.New;
            
        }
        public Notes CreateNotes(string sessioId, string atendeeId, string myNotes)
        {
            return new Notes(sessioId, atendeeId, myNotes);
        }
        public enum NotesStatus{
            New,
            Continue,
            Deleted,
            Edited
        }
    }
}
