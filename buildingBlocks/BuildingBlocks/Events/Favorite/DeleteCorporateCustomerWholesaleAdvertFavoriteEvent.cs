namespace BuildingBlocks.Events.Favorite
{
    public class DeleteCorporateCustomerWholesaleAdvertFavoriteEvent
    {
        public Guid CorporateCustomerId { get; set; }
        public Guid WholesaleAdvertId { get; set; }
    }
}
