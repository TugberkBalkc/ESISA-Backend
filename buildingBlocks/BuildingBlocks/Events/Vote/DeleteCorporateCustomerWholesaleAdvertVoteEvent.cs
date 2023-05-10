namespace BuildingBlocks.Events.Vote
{
    public class DeleteCorporateCustomerWholesaleAdvertVoteEvent
    {
        public Guid CorporateCustomerId { get; set; }
        public Guid WholesaleAdvertId { get; set; }
    }
}
