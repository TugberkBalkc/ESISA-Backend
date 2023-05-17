using BuildingBlocks.Events.Vote;
using ESISA.Core.Application.Dtos.Evaluation.Votes;
using ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.CreateCorporateAdvertVote;
using ESISA.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToAdvert.CreateCorporateAdvertComment
{
    public class CreateIndividualCustomerCorporateAdvertCommentCommandRequest : IRequest<CreateIndividualCustomerCorporateAdvertCommentCommandResponse>
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid CorporateAdvertId { get; set; }

        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }

        public CreateIndividualCustomerCorporateAdvertCommentCommandRequest()
        {

        }

        public CreateIndividualCustomerCorporateAdvertCommentCommandRequest(Guid ındividualCustomerId, Guid corporateAdvertId, string commentTitle, string commentContent)
        {
            IndividualCustomerId = ındividualCustomerId;
            CorporateAdvertId = corporateAdvertId;
            CommentTitle = commentTitle;
            CommentContent = commentContent;
        }
    }
}
