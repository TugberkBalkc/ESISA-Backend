using ESISA.Core.Domain.Constants;
using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class WholesaleAdvertOrderItem : EntityBase
    {
        public Guid WholesaleAdvertOrderId { get; set; }
        public Guid WholesaleAdvertId { get; set; }
    
        public int ProductAmount { get; set; }
        public decimal ProductUnitPrice { get; set; }
        public decimal DiscountedProductUnitPrice { get; set; }

        public virtual CorporateCustomerWholesaleAdvertOrder WholesaleAdvertOrder { get; set; }
        public virtual WholesaleAdvert WholesaleAdvert { get; set; }
    }
}
