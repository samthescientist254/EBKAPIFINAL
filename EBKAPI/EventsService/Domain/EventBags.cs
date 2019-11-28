using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
    public sealed class EventBags
    {
        public Guid Id { get; set; }
        public Event Event { get; private set; }
        public string FileName { get; private set; }
        public string FileLink { get; private set; }
        public string Description { get; private set; }
       // public Guid SessionId { get; private set; }
        public ResourceStatus Status { get; private set; }
        public void FileNameGenerator()
        {

        }
        public void FilePathGenerator()
        {

        }

        public EventBags() { }

        public EventBags(Guid eventid,string file)
        {
            Id = Guid.NewGuid();
            //FileName = fileName;
            //SessionId = sessioId;
            //Status = ResourceStatus.created;
            //File = file;

            Status = ResourceStatus.created;
        }
        public EventBags(Guid id)
        {
            Id = id;
            Status = ResourceStatus.deleted;
        }
        public EventBags AddResource(Guid sessioId, string file)
        {
            return new EventBags(sessioId,file);
        }
        public EventBags DeleteResource(Guid id)
        {
            return new EventBags(id);
        }
        public enum ResourceStatus
        {
            created,
            deleted,
            modified
        }
    }
}
