using ESISA.Core.Domain.Constants;
using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class WholesaleAdvert : EntityBase
    {
        public Guid AdvertId { get; set; }
        public Guid CorporateDealerId { get; set; }
        public Guid ProductId { get; set; }
        public Guid PurchaseQuantityDiscountId { get; set; } = Guid.Parse(DefaultDiscountValues.DefaultPurchaseQuantityDiscountId);

        public int StockAmount { get; set; }

        public int MinimumPurchaseAmount { get; set; }
        public int MaximumPurchaseAmount { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal DiscountedPricePerUnit { get; set; }


        public virtual Advert Advert { get; set; }
        public virtual CorporateDealer CorporateDealer { get; set; }
        public virtual Product Product { get; set; }
        public virtual PurchaseQuantityDiscount PurchaseQuantityDiscount { get; set; }

        public virtual ICollection<CorporateCustomerWholesaleAdvertComment> CorporateCustomerWholesaleAdvertComments { get; set; }
        public virtual ICollection<CorporateCustomerWholesaleAdvertFavorite> CorporateCustomerWholesaleAdvertFavorites { get; set; }
        public virtual ICollection<CorporateCustomerWholesaleAdvertVote> CorporateCustomerWholesaleAdvertVotes { get; set; }
      
        public virtual ICollection<WholesaleAdvertOrderItem> WholesaleAdvertOrderItems { get; set; }
    }
}
