using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Security.Authorization
{
    public class RoleOperationClaimDto
    {
        public Guid RoleOperationClaimId { get; set; }
        public DateTime RoleOperationClaimCreatedDate { get; set; }
        public DateTime RoleOperationClaimModifiedDate { get; set; }
        public bool RoleOperationClaimIsDeleted { get; set; }
        public bool RoleOperationClaimIsActive { get; set; }
        public Guid RoleId { get; set; }
        public Guid OperationClaimId { get; set; }

    }
}
