using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class Role : EntityBase
    {
        public String Name { get; set; }


        public virtual ICollection<RoleOperationClaim> RoleOperationClaims { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
