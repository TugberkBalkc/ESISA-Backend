using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Evaluation.Comments
{
    public class IndividualCustomerIndividualDealerCommentDto
    {
        public Guid IndividualCustomerIndividualDealerCommentId { get; set; }
        public DateTime IndividualCustomerIndividualDealerCommentCreatedDate { get; set; }
        public DateTime IndividualCustomerIndividualDealerCommentModifiedDate { get; set; }
        public bool IndividualCustomerIndividualDealerCommentIsActive { get; set; }
        public bool IndividualCustomerIndividualDealerCommentIsDeleted { get; set; }

        public Guid IndividualCustomerId { get; set; }
        public Guid IndividualDealerId { get; set; }

        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
    }
}
