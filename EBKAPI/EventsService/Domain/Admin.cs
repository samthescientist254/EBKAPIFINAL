using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
    public class Admin
    {
        public Guid Id { get;private set; }
        public string Name { get;private set; }
        public string PhoneNumber { get;private set; }
        public string Email { get;private set; }
        public string PhotoUrl { get;private set; }
        public string PasswordHash { get; set; }
        public Admin() { }
    }
}
