using AutoMapper;
using ESISA.Core.Application.Dtos.Evaluation.Votes;
using ESISA.Core.Application.Features.MediatR.Commands.Vote.ToAdvert.CreateCorporateAdvertVote;
using ESISA.Core.Application.Features.MediatR.Commands.Vote.ToAdvert.CreateWholesaleAdvertVote;
using ESISA.Core.Application.Features.MediatR.Commands.Vote.ToDealer.CreateIndividualDealerVote;
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

            this.CreateMap<CreateIndividualCustomerIndividualDealerVoteCommandHandler, IndividualCustomerIndividualDealerVoteDto>();

            this.CreateMap<CreateCorporateCustomerWholesaleAdvertVoteCommandRequest, CorporateCustomerWholesaleAdvertVoteDto>();

        
        }
    }
}
