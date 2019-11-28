
using EventService.Api.Commands.Dtos;
using EventsService.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Api.Domain
{
    public interface IUserService
    {
        Task<Speakers> Authenticate(AuthDto credentials);
        Speakers GetById(Guid id);

    }
}
