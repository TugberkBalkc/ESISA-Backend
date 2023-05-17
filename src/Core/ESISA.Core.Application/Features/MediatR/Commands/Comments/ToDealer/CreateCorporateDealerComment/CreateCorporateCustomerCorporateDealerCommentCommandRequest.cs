using ESISA.Core.Application.Features.MediatR.Commands.Comments.ToAdvert.CreateCorporateAdvertComment;
using ESISA.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToDealer.CreateCorporateDealerComment
{
    public class CreateCorporateCustomerCorporateDealerCommentCommandRequest : IRequest<CreateCorporateCustomerCorporateDealerCommentCommandResponse>
    {
        public Guid CorporateCustomerId { get; set; }
        public Guid CorporateDealerId { get; set; }

        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }

        public CreateCorporateCustomerCorporateDealerCommentCommandRequest()
        {

        }

        public CreateCorporateCustomerCorporateDealerCommentCommandRequest(Guid corporateCustomerId, Guid corporateDealerId, string commentTitle, string commentContent)
        {
            CorporateCustomerId = corporateCustomerId;
            CorporateDealerId = corporateDealerId;
            CommentTitle = commentTitle;
            CommentContent = commentContent;
        }
    }
}
