using ESISA.Core.Application.Features.MediatR.Commands.Comments.ToDealer.DeleteCorporateDealerComment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToDealer.DeleteIndivdualDealerComment
{
    public class DeleteIndividualCustomerIndividualDealerCommentCommandRequest : IRequest<DeleteIndividualCustomerIndividualDealerCommentCommandResponse>
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid IndividualDealerId { get; set; }
        public String CommentTitle { get; set; }
        public String CommentContent { get; set; }

        public DeleteIndividualCustomerIndividualDealerCommentCommandRequest()
        {

        }

        public DeleteIndividualCustomerIndividualDealerCommentCommandRequest(Guid individualCustomerId, Guid individualDealerId, string commentTitle, string commentContent)
        {
            IndividualCustomerId = individualCustomerId;
            IndividualDealerId = individualDealerId;
            CommentTitle = commentTitle;
            CommentContent = commentContent;
        }
    }
}
