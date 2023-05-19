using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Security.Authorization
{
    public class UserRoleDto
    {
        public Guid UserRoleId { get; set; }
        public DateTime UserRoleCreatedDate { get; set; }
        public DateTime UserRoleModifiedDate { get; set; }
        public bool UserRoleIsActive { get; set; }
        public bool UserRoleIsDeleted { get; set; }

        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

    }
}
