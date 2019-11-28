using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
    public class Venues
    {
        public Guid Id { get; private set; }
        public string Name { get;private set; }
        public string Location { get;private set; }
        public string InchargeContacts { get;private set; }
        public string InchargeEmail { get;private set; }
        public string InchargeFullNames { get;private set; }
        public VenueStatus Status { get; set; }

        public Venues() { }
        public Venues(string name,string location,string inchargeContacts,string inchargeEmail,string inchargeFullNames) {
            Id = Guid.NewGuid();
            Status = VenueStatus.Available;
            Name = name;
            Location = location;
            InchargeContacts = inchargeContacts;
            InchargeEmail = inchargeEmail;
            InchargeFullNames = inchargeFullNames;
        }
        public void BookVenue()
        {
            EnsureVenueIsAvailable();
            Status = VenueStatus.Booked;
        }

        public static Venues CreateVenue(string name, string location, string inchargeContacts, string inchargeEmail, string inchargeFullNames)
        {
            return new Venues(name, location, inchargeContacts, inchargeEmail, inchargeFullNames);
        }

        private void EnsureVenueIsAvailable()
        {
            if (Status != VenueStatus.Available)
            {
                throw new ApplicationException("Only Available Venues Can Be Booked");
            }
        }

    }
    public enum VenueStatus
    {
        Booked,
        Available
    }
}
