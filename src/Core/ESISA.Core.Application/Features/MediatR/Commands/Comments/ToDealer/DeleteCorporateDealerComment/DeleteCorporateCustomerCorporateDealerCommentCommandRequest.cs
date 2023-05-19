using ESISA.Core.Application.Dtos.Evaluation.Comments;
using ESISA.Core.Application.Features.MediatR.Commands.Comments.ToAdvert.DeleteWholesaleAdvertComment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToDealer.DeleteCorporateDealerComment
{
    public class DeleteCorporateCustomerCorporateDealerCommentCommandRequest : IRequest<DeleteCorporateCustomerCorporateDealerCommentCommandResponse>
    {
        public Guid CorporateCustomerId { get; set; }
        public Guid CorporateDealerId { get; set; }
        public String CommentTitle { get; set; }
        public String CommentContent { get; set; }

        public DeleteCorporateCustomerCorporateDealerCommentCommandRequest()
        {

        }

        public DeleteCorporateCustomerCorporateDealerCommentCommandRequest(Guid corporateCustomerId, Guid corporateDealerId, string commentTitle, string commentContent)
        {
            CorporateCustomerId = corporateCustomerId;
            CorporateDealerId = corporateDealerId;
            CommentTitle = commentTitle;
            CommentContent = commentContent;
        }
    }
}
