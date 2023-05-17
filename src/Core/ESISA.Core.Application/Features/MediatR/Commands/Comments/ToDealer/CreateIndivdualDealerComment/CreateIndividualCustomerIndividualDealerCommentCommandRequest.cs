using ESISA.Core.Application.Features.MediatR.Commands.Comments.ToAdvert.DeleteWholesaleAdvertComment;
using ESISA.Core.Application.Features.MediatR.Commands.Comments.ToDealer.CreateCorporateDealerComment;
using ESISA.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToDealer.CreateIndivdualDealerComment
{
    public class CreateIndividualCustomerIndividualDealerCommentCommandRequest : IRequest<CreateIndividualCustomerIndividualDealerCommentCommandResponse>
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid IndividualDealerId { get; set; }
        public String CommentTitle { get; set; }
        public String CommentContent { get; set; }

        public CreateIndividualCustomerIndividualDealerCommentCommandRequest()
        {

        }

        public CreateIndividualCustomerIndividualDealerCommentCommandRequest(Guid ındividualCustomerId, Guid ındividualDealerId, string commentTitle, string commentContent)
        {
            IndividualCustomerId = ındividualCustomerId;
            IndividualDealerId = ındividualDealerId;
            CommentTitle = commentTitle;
            CommentContent = commentContent;
        }
    }
}
