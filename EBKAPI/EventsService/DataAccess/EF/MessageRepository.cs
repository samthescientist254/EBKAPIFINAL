using EventService.Api.Commands.Dtos;
using EventsService.DataAccess.EF;
using EventsService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.DataAccess
{
    public class MessageRepository : IMessageRepository
    {
        private readonly EbkEventDbContextFinal3_ eventDbContext;
        public MessageRepository(EbkEventDbContextFinal3_ eventDbContext)
        {
            this.eventDbContext = eventDbContext ?? throw new ArgumentNullException(nameof(eventDbContext));

        }

        public async Task<Messages> Get(string EbkRegNumber)
        {
            return await eventDbContext.Messages.FirstOrDefaultAsync(e => e.MemberId == EbkRegNumber);

        }
        public async Task<Messages> NewMessage(Messages message)
        {
            eventDbContext.Messages.Add(message);
            await eventDbContext.SaveChangesAsync();
            return message;
        }

        public async Task<bool> Update(MessageDto message)
        {
            using (eventDbContext)
            {
                bool Updated = true;
                var Dbmessage = eventDbContext.Messages.FirstOrDefault(m => m.MemberId == message.SenderId);
                if (Dbmessage == null) throw new AppException("Message not found");
            
                if (!string.IsNullOrWhiteSpace(message.Message))
                    Dbmessage.Message = message.Message;
                
                eventDbContext.Messages.Update(Dbmessage);
                var saved = await eventDbContext.SaveChangesAsync();
                return Updated = saved > 0 ? true : false;
            }
        }
    }
}
