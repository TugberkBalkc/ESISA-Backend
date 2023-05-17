using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Evaluation.Comments
{
    public class IndividualCustomerCorporateAdvertCommentDto
    {
        public Guid IndividualCustomerCorporateAdvertCommentId { get; set; }
        public DateTime IndividualCustomerCorporateAdvertCommentCreatedDate { get; set; }
        public DateTime IndividualCustomerCorporateAdvertCommentModifiedDate { get; set; }
        public bool IndividualCustomerCorporateAdvertCommentIsActive { get; set; }
        public bool IndividualCustomerCorporateAdvertCommentIsDeleted { get; set; }

        public Guid IndividualCustomerId { get; set; }
        public Guid CorporateAdvertId { get; set; }

        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
    }
}
