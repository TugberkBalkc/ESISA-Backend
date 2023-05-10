namespace BuildingBlocks.Events.Favorite
{
    public class DeleteIndividualCustomerIndividualAdvertFavoriteEvent
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid IndividualAdvertId { get; set; }
    }
}
