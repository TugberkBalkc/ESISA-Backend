﻿namespace BuildingBlocks.Events.Comment
{
    public class DeleteCorporateCustomerWholesaleAdvertCommentEvent
    {
        public Guid CorporateCustomerId { get; set; }
        public Guid WholesaleAdvertId { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
    }
}
