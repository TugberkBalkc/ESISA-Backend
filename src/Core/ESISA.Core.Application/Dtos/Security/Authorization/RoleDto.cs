using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Security.Authorization
{
    public class RoleDto
    {
        public Guid RoleId { get; set; }
        public DateTime RoleCreatedDate { get; set; }
        public DateTime RoleModifiedDate { get; set; }
        public bool RoleIsDeleted { get; set; }
        public bool RoleIsActive { get; set; }
        public String RoleName { get; set; }
    }
}
