namespace BuildingBlocks.Events.Comment
{
    public class DeleteIndividualCustomerCorporateAdvertCommentEvent
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid CorporateAdvertId { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
    }
}
