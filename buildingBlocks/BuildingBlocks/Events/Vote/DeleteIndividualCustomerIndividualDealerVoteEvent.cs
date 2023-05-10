namespace BuildingBlocks.Events.Vote
{
    public class DeleteIndividualCustomerIndividualDealerVoteEvent
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid IndividualDealerId { get; set; }
    }
}
