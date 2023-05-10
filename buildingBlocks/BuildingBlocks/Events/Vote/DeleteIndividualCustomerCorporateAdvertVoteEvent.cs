namespace BuildingBlocks.Events.Vote
{
    public class DeleteIndividualCustomerCorporateAdvertVoteEvent
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid CorporateAdvertId { get; set; }
    }
}
