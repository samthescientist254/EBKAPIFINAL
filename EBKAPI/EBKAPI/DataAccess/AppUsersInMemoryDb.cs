using AuthService.Domain;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.DataAccess
{
    public class AppUsersInMemoryDb : IAppUser
    {
        private readonly IDictionary<string, AppUsers> db = new ConcurrentDictionary<string, AppUsers>();
        public AppUsersInMemoryDb()
        {
            Add(new AppUsers("papa.jerry", "secret", new List<string>() { "TRI", "HSI", "FAI", "CAR" }));
            Add(new AppUsers("admin", "admin", new List<string>() { "TRI", "HSI", "FAI", "CAR" }));
        }
        public void Add(AppUsers user)
        {
            db[user.Login] = user;
        }

        public AppUsers FindByLogin(string login) => db[login];
        
    }
}
