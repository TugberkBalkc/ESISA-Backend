using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class Product : EntityBase
    {
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }

        public String Name { get; set; }


        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }

        public virtual ICollection<CorporateAdvert> CorporateAdverts { get; set; }
        public virtual ICollection<IndividualAdvert> IndividualAdverts { get; set; }
        public virtual ICollection<SwapAdvert> SwapAdverts { get; set; }
        public virtual ICollection<WholesaleAdvert> WholesaleAdverts { get; set; }

        public virtual ICollection<SwapAdvertSwapableProduct> SwapAdvertSwapableProducts { get; set; }
    }
}
