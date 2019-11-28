using EventService.Api.Commands.Dtos;
using EventsService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.DataAccess.EF
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly EbkEventDbContextFinal3_ eventDbContext;
        public QuestionRepository(EbkEventDbContextFinal3_ eventDbContext)
        {
            this.eventDbContext = eventDbContext ?? throw new ArgumentNullException(nameof(eventDbContext));
        }
        public async Task<bool> Respond(QuestionsDto questions)
        {
            bool Updated = true;
            var question = eventDbContext.Questions.FirstOrDefault(q => q.Id == questions.Id);

            if (question == null) throw new AppException("Question not found");
            if (questions.RespondentId != null)
                question.RespondentId = questions.RespondentId;
            if (!string.IsNullOrWhiteSpace(questions.ResponseBody))
                question.ResponseBody = questions.ResponseBody;
            question.ResponseDate = DateTime.Now;
            question.Status = Status.Responded;
            eventDbContext.Questions.Update(question);
            var saved = await eventDbContext.SaveChangesAsync();
            return Updated = saved > 0 ? true : false;
        }

        public async Task<Questions> Post(Questions questions)
        {
            eventDbContext.Questions.Add(questions);
            await eventDbContext.SaveChangesAsync();
            return questions;
        }

        public async Task<List<Questions>> FindUnanswered(Guid sessionId)
        {
            return await eventDbContext
                .Questions
                .Where(e => e.Status != Status.Responded && e.SessionId == sessionId).Where(k=>k.Status==Status.Approved)/*.Include(a => a.SessionId).Include(s=>s.PosterId)*/
                .ToListAsync();
        }

        public async Task<Questions> FindOne(Guid id)
        {
            return await eventDbContext.Questions.FirstOrDefaultAsync(e => e.Id == id);

        }

        public async Task<List<Questions>> FindMyQuestions(Guid posterId)
        {
            return await eventDbContext.Questions.Where(q => q.PosterId == posterId).Where(r =>r.Status==Status.Approved)./*.Include(s=>s.RespondentId).Include(s=>s.SessionId).*/ToListAsync();
        }
    }
}
