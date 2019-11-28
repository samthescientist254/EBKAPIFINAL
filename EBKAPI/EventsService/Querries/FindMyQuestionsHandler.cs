using EventService.Api.Queries;
using EventService.Api.Queries.Dtos;
using EventsService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EventsService.Querries
{
    public class FindMyQuestionsHandler : IRequestHandler<FindMyQuestionsQuerry, IEnumerable<QuestionQuerryDto>>
    {
        private readonly IQuestionRepository questionRepository;
        public FindMyQuestionsHandler(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
        }
        public async Task<IEnumerable<QuestionQuerryDto>> Handle(FindMyQuestionsQuerry request, CancellationToken cancellationToken)
        {
            var result = await questionRepository.FindMyQuestions(request.posterId);
            return result.Select(p => new QuestionQuerryDto
            {
                QuestionBody = p.QuestionBody,
                PostingDate = p.PostingDate,
                ResponseBody=p.ResponseBody,
                Status = p.Status.ToString(),
                Id=p.Id
            }
            ).ToList();
        }
    }
}
