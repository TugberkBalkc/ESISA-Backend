namespace BuildingBlocks.Events.Comment
{
    public class DeleteIndividualCustomerIndividualDealerCommentEvent
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid IndividualDealerId { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
    }
}
