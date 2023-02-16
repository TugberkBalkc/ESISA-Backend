using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class UserRole : EntityBase
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }


        public virtual User User { get; set; }
        public virtual Role Role { get; set; }


    }
}
