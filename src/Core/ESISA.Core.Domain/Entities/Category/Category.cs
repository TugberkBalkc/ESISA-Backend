using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class Category : EntityBase
    {
        public String Name { get; set; }
        public String Description { get; set; }

        public Guid? ParentId { get; set; }

        public virtual Category? Parent { get; set; }

        public virtual ICollection<Category>? Children { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductDemand> ProductDemands { get; set; }

        public virtual ICollection<CategoryPhotoPath> CategoryPhotoPaths { get; set; }

        public virtual ICollection<CorporateDealer> CorporateDealersSalesCategory { get; set; }

        public virtual ICollection<SwapAdvertSwapableCategory> SwapAdvertSwapableCategories { get; set; }

    }
}
