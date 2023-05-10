namespace BuildingBlocks.Events.Favorite
{
    public class DeleteIndividualCustomerCorporateAdvertFavoriteEvent
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid CorporateAdvertId { get; set; }
    }
}
