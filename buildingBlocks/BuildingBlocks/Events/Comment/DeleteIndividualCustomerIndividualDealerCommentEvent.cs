namespace BuildingBlocks.Events.Comment
{
    public class DeleteIndividualCustomerIndividualDealerCommentEvent
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid IndividualDealerId { get; set; }
    }
}
