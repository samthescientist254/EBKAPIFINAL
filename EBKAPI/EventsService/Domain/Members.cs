using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
    public class Members
    {
        public Guid Id { get;  set; }
        public string Image { get;  set; }
        public string FirstName { get;  set; }
        public string UserName { get;  set; }
        public string LastName { get;  set; }
        //public string Password { get;  set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string OrganisationName { get;  set; }
        public string Email { get;  set; }
        public string Phone { get;  set; }
        public bool? Registered { get;  set; }
        public OriginCountry Country { get;  set; }
        //public string MessageId { get; set; }
        //public Messages Message { get;  set; }
        public MembershipStatus? Status { get;  set; }
        public string EbkRegNumber { get; set; }
        public Gender? Gender { get;  set; }
        public ValidEbkMember? EbkStatus { get;  set; }
        public Members() { }
        public Members(string ebkRegNo)
        {
            EbkRegNumber = ebkRegNo;
        }
        public Members(string image, string firstName, string lastName, string organisationName, string email, string phone, string ebkRegNo)
        {
            EnsureAtendantIsEbkMember();
            Id = Guid.NewGuid();
            Image = image;
            FirstName = firstName;
            LastName = lastName;
            OrganisationName = organisationName;
            Email = email;
            Phone = phone;
            EbkRegNumber = ebkRegNo;
            Country = Country;
            Status = MembershipStatus.Active;
            Gender = Gender;
        }

        public Members CreateMember(string image, string firstName, string lastName, string organisationName, string email, string phone, string ebkRegNo)
        {
            return new Members(image, firstName, lastName, organisationName, email, phone, ebkRegNo);
        }
        private void EnsureAtendantIsEbkMember()
        {
            if (EbkStatus != ValidEbkMember.True)
            {
                throw new ApplicationException("Only Registered Ebk Members are eligible for attendance");
            }
        }
    }
    public class OriginCountry
    {
        public Guid Id { get;  set; }
        public string Name { get; private set; }
        public string ZipCode { get; private set; }
    }
    public enum MembershipStatus
    {
        Active,
        Dormant,
        Suspended,
        Registered
    }
    public enum ValidEbkMember
    {
        True,
        False
    }
    public enum Gender
    {
        Male,
        Female
    }
}
