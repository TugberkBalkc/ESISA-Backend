using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Events.Comment
{
    public class CreateCorporateCustomerWholesaleAdvertCommentEvent
    {
        public Guid CorporateCustomerId { get; set; }
        public Guid WholesaleAdvertId { get; set; }

        public String Title { get; set; }
        public String Content { get; set; }
    }
}
