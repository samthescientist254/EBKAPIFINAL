using EventsService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Init
{
    internal static class DemoEventFactory
    {
        internal static Event EventOne()
        {
            var p = Event.CreateDraftEvent(
              
                "test event one",
                null,
                "first seeded event",
                "nairobi",
                "test title"
                );
            p.AddSpeaker("papa", "jerry", "jerrybrads38@gmail.com", "0704514301", "fintech", "associate azure solutions architect consultant", "Ev001", null, "developer");
            p.AddSponsor("Ev001", "delarge group", "delargegroup@gmail.com", "0721320158", "tech firm", null, "www.delarge.com");
            p.ActivateEvent();
            return p;
        }
    }
}
