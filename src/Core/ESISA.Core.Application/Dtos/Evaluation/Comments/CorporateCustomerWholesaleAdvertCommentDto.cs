using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Evaluation.Comments
{
    public class CorporateCustomerWholesaleAdvertCommentDto
    {
        public Guid CorporateCustomerWholesaleAdvertCommentId { get; set; }
        public DateTime CorporateCustomerWholesaleAdvertCommentCreatedDate { get; set; }
        public DateTime CorporateCustomerWholesaleAdvertCommentModifiedDate { get; set; }
        public bool CorporateCustomerWholesaleAdvertCommentIsActive { get; set; }
        public bool CorporateCustomerWholesaleAdvertCommentIsDeleted { get; set; }

        public Guid CorporateCustomerId { get; set; }
        public Guid WholesaleAdvertId { get; set; }

        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
    }
}
