using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class CategoryPhotoPath : EntityBase
    {
        public Guid CategoryId { get; set; }
        public String PhotoPath { get; set; }

        public virtual Category Category { get; set; }
    }
}
