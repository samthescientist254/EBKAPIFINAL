using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Commands.Dtos
{
    public class MemberDto
    {
        public string Image { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EbkRegNumber { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string OrganisationName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid Country { get; set; }
        //
        public int Status { get; set; }
        public int Gender { get; set; }
        public int Validity { get; set; }
       
    }
}
