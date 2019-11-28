
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Queries.Dtos
{
    public class AtendeeDto
    {
        public Guid PosterID { get;  set; }
        public DateTime? RegistrationDate { get;  set; }
        public string EventCode { get;  set; }
        public string EbKRegNumber { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Email { get;  set; }
        public string Telephone { get;  set; }
        public string Organisation { get;  set; }
        public string Image { get;  set; }
        public string Gender { get;  set; }
        public string OriginCountry { get;  set; }
        public string MessageToken { get;  set; }
        public Guid MessageId { get;  set; }
    }
}
