using AutoMapper;
using ESISA.Core.Application.Dtos.Evaluation.Comments;
using ESISA.Core.Application.Dtos.Evaluation.Votes;
using ESISA.Core.Application.Features.MediatR.Commands.Comments.ToAdvert.CreateCorporateAdvertComment;
using ESISA.Core.Application.Features.MediatR.Commands.Comments.ToAdvert.CreateWholesaleAdvertComment;
using ESISA.Core.Application.Features.MediatR.Commands.Comments.ToDealer.CreateIndivdualDealerComment;
using ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.CreateCorporateAdvertVote;
using ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.CreateWholesaleAdvertVote;
using ESISA.Core.Application.Features.MediatR.Commands.Votes.ToDealer.CreateIndividualDealerVote;
using ESISA.Core.Domain.Entities;
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

            this.CreateMap<CreateIndividualCustomerIndividualDealerVoteCommandRequest, IndividualCustomerIndividualDealerVoteDto>();

            this.CreateMap<CreateCorporateCustomerWholesaleAdvertVoteCommandRequest, CorporateCustomerWholesaleAdvertVoteDto>();


            this.CreateMap<CreateIndividualCustomerCorporateAdvertCommentCommandRequest, IndividualCustomerCorporateAdvertCommentDto>();

            this.CreateMap<CreateIndividualCustomerIndividualDealerCommentCommandRequest, IndividualCustomerIndividualDealerCommentDto>();

            this.CreateMap<CreateCorporateCustomerWholesaleAdvertCommentCommandRequest, CorporateCustomerWholesaleAdvertCommentDto>();

     //       this.CreateMap<CreateCorporateCustomerCorporateDealerCommentCommandRequest, CorporateCustomerCorporateDealerCommentDto>();
        }
    }
}
