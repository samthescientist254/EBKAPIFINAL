using EventService.Api.Commands;
using EventsService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EventsService.Commands
{
    public class AnswerQuestionsHandler : IRequestHandler<AnswerQuestionCommand, AnswerQuestionResult>
    {
        private readonly IQuestionRepository question;
        public AnswerQuestionsHandler(IQuestionRepository question)
        {
            this.question = question ?? throw new ArgumentNullException(nameof(question));
        }
        public async Task<AnswerQuestionResult> Handle(AnswerQuestionCommand request, CancellationToken cancellationToken)
        {
            var NewAnswer =await question.Respond(request.questionAnswer);
            return new AnswerQuestionResult
            {
                Status = NewAnswer
            };
        }
    }
}
