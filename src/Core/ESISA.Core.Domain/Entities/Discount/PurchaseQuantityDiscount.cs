using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class PurchaseQuantityDiscount : Discount
    {
        public int MinimumBuyingQuantity { get; set; }
        public int MaximumBuyingQuantity { get; set; }

        public virtual ICollection<CorporateAdvert> CorporateAdverts { get; set; }
        public virtual ICollection<WholesaleAdvert> WholesaleAdverts { get; set; }
    }
}
