using ESISA.Core.Domain.Constants;
using ESISA.Core.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class CorporateAdvert : EntityBase
    {
        public Guid AdvertId { get; set; }
        public Guid CorporateDealerId { get; set; }
        public Guid ProductId { get; set; }
        public Guid PurchaseQuantityDiscountId { get; set; } = Guid.Parse(DefaultDiscountValues.DefaultPurchaseQuantityDiscountId);

        public int StockAmount { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Advert Advert { get; set; }
        public virtual CorporateDealer CorporateDealer { get; set; } 
        public virtual Product Product { get; set; }

        public virtual PurchaseQuantityDiscount PurchaseQuantityDiscount { get; set; }

        public virtual ICollection<IndividualCustomerCorporateAdvertComment> IndividualCustomerCorporateAdvertComments { get; set; }
        public virtual ICollection<IndividualCustomerCorporateAdvertFavorite> IndividualCustomerCorporateAdvertFavorites { get; set; }
        public virtual ICollection<IndividualCustomerCorporateAdvertVote> IndividualCustomerCorporateAdvertVotes { get; set; }

        public virtual ICollection<CorporateAdvertOrderItem> CorporateAdvertOrderItems { get; set; }
    }
}
