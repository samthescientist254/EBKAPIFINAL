using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Domain
{
    public class AppUsers
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        //public string Login { get;private set; }
        //public string Password { get;private set; }
        //public List<string> Events { get;private set; }

        //public AppUsers(string login,string password,List<string> events)
        //{
        //    Login = login;
        //    Password = password;
        //    Events = events;
        //}
        //public bool PasswordMatches(string passwordToTest) => Password == passwordToTest;
    }
}
