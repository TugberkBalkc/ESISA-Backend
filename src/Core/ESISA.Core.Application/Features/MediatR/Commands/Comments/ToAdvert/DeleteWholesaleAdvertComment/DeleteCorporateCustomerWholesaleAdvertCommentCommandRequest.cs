using BuildingBlocks.Events.Vote;
using ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.DeleteWholesaleAdvertVote;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToAdvert.DeleteWholesaleAdvertComment
{
    public class DeleteCorporateCustomerWholesaleAdvertCommentCommandRequest : IRequest<DeleteCorporateCustomerWholesaleAdvertCommentCommandResponse>
    {
        public Guid CorporateCustomerId { get; set; }
        public Guid WholesaleAdvertId { get; set; }

        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }

        public DeleteCorporateCustomerWholesaleAdvertCommentCommandRequest()
        {

        }

        public DeleteCorporateCustomerWholesaleAdvertCommentCommandRequest(Guid corporateCustomerId, Guid wholesaleAdvertId, string commentTitle, string commentContent)
        {
            CorporateCustomerId = corporateCustomerId;
            WholesaleAdvertId = wholesaleAdvertId;
            CommentTitle = commentTitle;
            CommentContent = commentContent;
        }
    }
}
