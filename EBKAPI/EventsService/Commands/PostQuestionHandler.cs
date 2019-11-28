using EventService.Api.Commands;
using EventsService.DataAccess.EF;
using EventsService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EventsService.Commands
{
    public class PostQuestionHandler : IRequestHandler<PostQuestionCommand, PostQuestionResult>
    {
        private readonly IQuestionRepository question;
        private readonly EbkEventDbContextFinal3_ eventDbContext;
        // EbkEventDbContextFinal3_ eventDbContext =new EbkEventDbContextFinal3_();
        public PostQuestionHandler(IQuestionRepository question, EbkEventDbContextFinal3_ context)
        {
            this.question = question ?? throw new ArgumentNullException(nameof(question));
            this.eventDbContext = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<PostQuestionResult> Handle(PostQuestionCommand request, CancellationToken cancellationToken)
        {
            var evcode = eventDbContext.EventSessions.FirstOrDefault(s => s.Id == request.questions.SessionId).EventCode;
            var evid = eventDbContext.Events.FirstOrDefault(e => e.Code == evcode).Id;
            var Newquestion = Questions.AddNewQuestion(
               request.questions.QuestionBody,
               request.questions.PosterId,
               request.questions.SessionId,
               evid
               //request.questions.EventId
               );
            await question.Post(Newquestion);

            return new PostQuestionResult
            {
                QuestionId = Newquestion.Id
            };
        }
    }
}
