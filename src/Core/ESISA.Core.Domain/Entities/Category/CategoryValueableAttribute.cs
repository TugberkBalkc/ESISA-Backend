using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class CategoryValueableAttribute : EntityBase
    {
        public Guid CategoryId { get; set; }
        public Guid ValueableAttributeId { get; set; }
        public double Value { get; set; }

        public virtual Category Category { get; set; }
        public virtual ValueableAttribute ValueableAttribute { get; set; }
    }
}
