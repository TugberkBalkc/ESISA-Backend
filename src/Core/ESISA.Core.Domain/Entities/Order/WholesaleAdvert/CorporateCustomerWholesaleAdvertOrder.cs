using ESISA.Core.Domain.Constants;
using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class CorporateCustomerWholesaleAdvertOrder : EntityBase
    {
        public Guid OrderId { get; set; }
        public Guid CorporateDealerId { get; set; }
        public Guid CorporateCustomerId { get; set; }
        public Guid CorporateCustomerAddressId { get; set; }

        public decimal TotalPrice { get; set; }
        public decimal DiscountedTotalPrice { get; set; }


        public virtual Order Order { get; set; }
        public virtual CorporateDealer CorporateDealer { get; set; }
        public virtual CorporateCustomer CorporateCustomer { get; set; }
        public virtual CorporateCustomerAddress CorporateCustomerAddress { get; set; }

        public virtual ICollection<WholesaleAdvertOrderItem> WholesaleAdvertOrderItems { get; set; }
    }
}
