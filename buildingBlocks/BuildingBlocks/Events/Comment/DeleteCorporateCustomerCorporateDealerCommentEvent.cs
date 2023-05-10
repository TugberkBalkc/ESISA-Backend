namespace BuildingBlocks.Events.Comment
{
    public class DeleteCorporateCustomerCorporateDealerCommentEvent
    {
        public Guid CorporateCustomerId { get; set; }
        public Guid CorporateDealerId { get; set; }
    }
}
