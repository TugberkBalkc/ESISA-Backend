using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class ProductDemand : Demand
    {
        public Guid CategoryId { get; set; }
        public String ProductName { get; set; }

        public virtual Category Category { get; set; }
    }
}
