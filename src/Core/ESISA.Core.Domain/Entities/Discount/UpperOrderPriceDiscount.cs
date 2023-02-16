using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class UpperOrderPriceDiscount : Discount
    {
        public decimal MinimumOrderPrice { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
