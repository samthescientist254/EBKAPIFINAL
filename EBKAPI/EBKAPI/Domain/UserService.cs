using EventsService.DataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Domain
{
    public class UserService:IUserService
    {
        private readonly EventDbContext _context;
        public UserService(EventDbContext context)
        {
            _context = context;
        }

        public AppUsers Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Membership.SingleOrDefault(x => x.UserName == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }
    }
}
