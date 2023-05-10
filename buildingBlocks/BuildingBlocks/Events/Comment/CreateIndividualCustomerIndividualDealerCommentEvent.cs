using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Events.Comment
{
    public class CreateIndividualCustomerIndividualDealerCommentEvent
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid IndividualDealerId { get; set; }

        public String Title { get; set; }
        public String Content { get; set; }
    }
}
