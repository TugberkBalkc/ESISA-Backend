using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Roles.Update
{
    public class UpdateRoleCommandRequest : IRequest<UpdateRoleCommandResponse>
    {
        public Guid RoleId { get; set; }
        public bool RoleIsActive { get; set; }
        public String RoleName { get; set; }

        public UpdateRoleCommandRequest()
        {

        }

        public UpdateRoleCommandRequest(Guid roleId, bool roleIsActive, string roleName)
        {
            RoleId = roleId;
            RoleIsActive = roleIsActive;
            RoleName = roleName;
        }
    }
}
