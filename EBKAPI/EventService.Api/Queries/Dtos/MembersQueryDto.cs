using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Queries.Dtos
{
  public  class MembersQueryDto
    {
        public Guid Id { get;  set; }
        public string Image { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string OrganisationName { get;  set; }
        public string Email { get;  set; }
        public string Phone { get;  set; }
       // public string Country { get;  set; }
        public string Status { get;  set; }
        public string EbkRegNumber { get; set; }
        public string UserName { get; set; }
        public string Gender { get;  set; }
    }
}
