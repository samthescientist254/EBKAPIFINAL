using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Domain
{
    public interface IAppUser
    {
        void Add(AppUsers user);
        AppUsers FindByLogin(string login);
    }
}
