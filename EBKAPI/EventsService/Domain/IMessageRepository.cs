using EventService.Api.Commands.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
    public interface IMessageRepository
    {
        Task<Messages> NewMessage(Messages message);
        Task<bool> Update(MessageDto message);
        Task<Messages> Get(string EbkRegNumber);
    }
}
