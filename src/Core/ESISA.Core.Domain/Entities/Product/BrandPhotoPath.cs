using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class BrandPhotoPath : EntityBase
    {
        public Guid BrandId { get; set; }
        public String PhotoPath { get; set; }


        public virtual Brand Brand { get; set; }
    }
}
