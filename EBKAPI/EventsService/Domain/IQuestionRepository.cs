using EventService.Api.Commands.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.Domain
{
    public interface IQuestionRepository
    {
        Task<Questions> Post(Questions questions);
        Task<bool> Respond(QuestionsDto questions);
        Task<List<Questions>> FindUnanswered(Guid sessionId);
        Task<List<Questions>> FindMyQuestions(Guid posterId);
        Task<Questions> FindOne(Guid id);
    }
}
