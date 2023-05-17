using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToAdvert.DeleteCorporateAdvertComment
{
    public class DeleteIndividualCustomerCorporateAdvertCommentCommandRequest : IRequest<DeleteIndividualCustomerCorporateAdvertCommentCommandResponse>
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid CorporateAdvertId { get; set; }

        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }

        public DeleteIndividualCustomerCorporateAdvertCommentCommandRequest()
        {

        }

        public DeleteIndividualCustomerCorporateAdvertCommentCommandRequest(Guid ındividualCustomerId, Guid corporateAdvertId, string commentTitle, string commentContent)
        {
            IndividualCustomerId = ındividualCustomerId;
            CorporateAdvertId = corporateAdvertId;
            CommentTitle = commentTitle;
            CommentContent = commentContent;
        }
    }
}
