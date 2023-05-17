using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Evaluation.Comments
{
    public class CorporateCustomerCorporateDealerCommentDto
    {
        public Guid CorporateCustomerCorporateDealerCommentId { get; set; }
        public DateTime CorporateCustomerCorporateDealerCommentCreatedDate { get; set; }
        public DateTime CorporateCustomerCorporateDealerCommentModifiedDate { get; set; }
        public bool CorporateCustomerCorporateDealerCommentIsActive { get; set; }
        public bool CorporateCustomerCorporateDealerCommentIsDeleted { get; set; }

        public Guid CorporateCustomerId { get; set; }
        public Guid CorporateDealerId { get; set; }

        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
    }
}
