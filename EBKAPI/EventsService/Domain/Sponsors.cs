using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
    public class Sponsors
    {
        public Guid Id { get;private set; }
        public string EventCode { get; private set; }
        public string Image { get; private set; }
        public string Name { get; private set; }
        public string EmailAddress { get; private set; }
        public string WebSiteLink { get; private set; }
        public string CellContacts { get; private set; }
        public string MoreInfo { get; private set; }
        public Event Event { get; private set; }

        public Sponsors() { }

        public Sponsors(string eventCode,string name,string email,string contacts,string moreInfo, string image,string webSiteLink)
        {
            Id = Guid.NewGuid();
            EventCode = eventCode;
            Name = name;
            EmailAddress = email;
            CellContacts = contacts;
            MoreInfo = moreInfo;
            Image = image;
            WebSiteLink = webSiteLink;
        }

        public static Sponsors CreateSponsor(string code, string name, string email, string contacts, string moreInfo, string image, string webSiteLink)
        {
            return new Sponsors(code, name, email, contacts, moreInfo, image, webSiteLink);
        }

    }
}
