using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class Brand : EntityBase
    {
        public String Name { get; set; }
        public String WebsiteUrl { get; set; }


        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<BrandPhotoPath> BrandPhotoPaths { get; set; }
    }
}
