using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class CorporateAdvertOrderItem : EntityBase
    {
        public Guid CorporateAdvertOrderId { get; set; }
        public Guid CorporateAdvertId { get; set; }

        public int ProductAmount { get; set; }
        public decimal ProductUnitPrice { get; set; }
        public decimal DiscountedProductUnitPrice { get; set; }

        public virtual IndividualCustomerCorporateAdvertOrder CorporateAdvertOrder { get; set; }
        public virtual CorporateAdvert CorporateAdvert { get; set; }
    }
}
