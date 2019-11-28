
using AuthService.Api.Domain;
using EventService.Api.Commands.Dtos;
using EventsService.DataAccess.EF;
using EventsService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsService.DataAccess.EF
{
    public class UserService : IUserService
    {
        private readonly EbkEventDbContextFinal3_ eventDbContext;
        public UserService(EbkEventDbContextFinal3_ eventDbContext)
        {
            this.eventDbContext = eventDbContext ?? throw new ArgumentNullException(nameof(eventDbContext));
        }

        public async Task<Speakers> Authenticate(AuthDto credentials)
        {
            if (string.IsNullOrWhiteSpace(credentials.Email) || string.IsNullOrWhiteSpace(credentials.EventCode)) return null;
            var user = eventDbContext.Speakers.SingleOrDefault(x => x.Email == credentials.Email);
            if (user == null) return null;
            if (user.Email != credentials.Email && user.EventCode != credentials.EventCode) return null;
            return user;
        }

        public Speakers GetById(Guid id)
        {
            return eventDbContext.Speakers.Find(id);
        }
    }
}
