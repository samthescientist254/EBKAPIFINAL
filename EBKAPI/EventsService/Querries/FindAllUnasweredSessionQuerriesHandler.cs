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
    public class FindAllUnasweredSessionQuerriesHandler : IRequestHandler<FindAllUnasweredSessionQuestionsQuery, IEnumerable<QuestionQuerryDto>>
    {
        private readonly IQuestionRepository questionRepository;
        public FindAllUnasweredSessionQuerriesHandler(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
        }
        public async Task<IEnumerable<QuestionQuerryDto>> Handle(FindAllUnasweredSessionQuestionsQuery request, CancellationToken cancellationToken)
        {
            var result = await questionRepository.FindUnanswered(request.SessionId);
            return result.Select(p => new QuestionQuerryDto
            {
                QuestionBody=p.QuestionBody,
                PostingDate=p.PostingDate,
                Status=p.Status.ToString(),
                PosterId=p.PosterId,
                Id=p.Id
                //RespondentEmail=p.Respondent.Email,
                //PosterEmail=p.Poster.Members.Email,
                //PosterName=p.Poster.Members.FirstName,
                //PosterOrganisation=p.Poster.Members.OrganisationName,
                //PosterTelephone=p.Poster.Members.Phone,
                //RespondentName=p.Respondent.FirstName,
                //SessionTitle=p.Session.Name  
            }
            ).ToList();
        }
    }
}
