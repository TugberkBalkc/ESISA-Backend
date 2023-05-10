using AutoMapper;
using ESISA.Core.Application.Dtos.Evaluation.Votes;
using ESISA.Core.Application.Features.MediatR.Commands.Vote.ToAdvert.CreateCorporateAdvertVote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class EvaluationProfile : Profile
    {
        public EvaluationProfile()
        {
            this.CreateMap<CreateIndividualCustomerCorporateAdvertVoteCommandRequest, IndividualCustomerCorporateAdvertVoteDto>();
        }
    }
}
