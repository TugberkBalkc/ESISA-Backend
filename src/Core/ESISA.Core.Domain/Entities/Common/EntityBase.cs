using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities.Common
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
