using EventService.Api.Commands.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventService.Api.Commands
{
   public class AnswerQuestionCommand:IRequest<AnswerQuestionResult>
    {
        public QuestionsDto questionAnswer { get; set; }
    }
}
