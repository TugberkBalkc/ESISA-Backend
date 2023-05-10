namespace BuildingBlocks.Events.Comment
{
    public class DeleteIndividualCustomerCorporateAdvertCommentEvent
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid CorporateAdvertId { get; set; }
    }
}
