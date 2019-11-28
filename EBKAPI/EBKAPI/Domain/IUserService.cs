using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Domain
{
   public interface IUserService
    {
        AppUsers Authenticate(string username, string password);
    }
}
