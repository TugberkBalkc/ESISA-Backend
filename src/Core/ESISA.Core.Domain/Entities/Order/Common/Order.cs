using ESISA.Core.Domain.Constants;
using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class Order : EntityBase
    {
        public Guid UpperOrderPriceDiscountId { get; set; } = Guid.Parse(DefaultDiscountValues.DefaultUpperOrderPriceDiscountId);
        public String Description { get; set; }
        public String Code { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountedTotalPrice { get; set; }

        public virtual UpperOrderPriceDiscount UpperOrderPriceDiscount { get; set; }
        
        public virtual CompletedOrder CompletedOrder { get; set; }
        public virtual ReturnedOrder ReturnedOrder { get; set; }

        public virtual IndividualCustomerCorporateAdvertOrder IndividualCustomerCorporateAdvertOrder { get; set; }
        public virtual CorporateCustomerWholesaleAdvertOrder CorporateCustomerWholesaleAdvertOrder { get; set; }
    }
}
