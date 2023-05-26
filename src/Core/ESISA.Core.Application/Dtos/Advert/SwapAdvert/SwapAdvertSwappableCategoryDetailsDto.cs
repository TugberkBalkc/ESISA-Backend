namespace ESISA.Core.Application.Dtos.Advert.SwapAdvert
{
    public class SwapAdvertSwappableCategoryDetailsDto
    {
        public Guid SwapAdvertSwappableCategoryId { get; set; }
        public DateTime SwapAdvertSwappableCategoryCreatedDate { get; set; }
        public DateTime SwapAdvertSwappableCategoryModifiedDate { get; set; }
        public bool SwapAdvertSwappableCategoryIsActive { get; set; }
        public bool SwapAdvertSwappableCategoryIsDeleted { get; set; }

        public Guid CategoryId { get; set; }
        public String CategoryName { get; set; }
        public Guid SwapAdvertId { get; set; }

    }
}
