using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
    public sealed class Speakers
    {
        public Guid Id { get; set; }
        public string FirstName { get;  set; }
        public string Image { get;  set; }
        public string LastName { get;  set; }
        public string Email { get;  set; }
        public string PhoneNumber { get;  set; }
        public string OriginCompany { get;  set; }
        public string Title { get;  set; }
        public string MoreInfo { get;  set; }
        public string EventCode { get;  set; }
        public Event Event { get;  set; }
        public Speakers() { }
        public Speakers(string firstName,string lastName,string email,string phoneNumber,string originCompany,string moreInfo,string eventCode, string image,string title)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            OriginCompany = originCompany;
            MoreInfo = moreInfo;
            EventCode = eventCode;
            Image = image;
            Title = title;
        }
        public static Speakers CreateSpeaker(string firstName, string lastName, string email, string phoneNumber, string originCompany, string moreInfo, string eventCode, string image, string title)
        {
            return new Speakers(firstName, lastName, email, phoneNumber, originCompany, moreInfo,eventCode,image,title);
        }
    }
}
