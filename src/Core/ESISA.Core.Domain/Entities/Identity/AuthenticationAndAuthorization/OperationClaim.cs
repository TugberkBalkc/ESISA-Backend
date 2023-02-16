using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class OperationClaim : EntityBase
    {
        public String ClaimName { get; set; }


        public virtual ICollection<RoleOperationClaim> RoleOperationClaims { get; set; }
    }
}
