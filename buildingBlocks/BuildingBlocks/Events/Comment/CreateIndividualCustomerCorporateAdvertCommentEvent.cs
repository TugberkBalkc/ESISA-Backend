using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Events.Comment
{
    public class CreateIndividualCustomerCorporateAdvertCommentEvent
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid CorporateAdvertId { get; set; }

        public String Title { get; set; }
        public String Content { get; set; }
    }
}
