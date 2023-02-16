using ESISA.Core.Domain.Entities.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class RoleOperationClaim : EntityBase
    {
        public Guid RoleId { get; set; }
        public Guid OperationClaimId { get; set; }


        public virtual Role Role { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }
    }
}
