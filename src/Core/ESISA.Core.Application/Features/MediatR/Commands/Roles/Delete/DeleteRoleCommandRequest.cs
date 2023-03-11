using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Roles.Delete
{
    public class DeleteRoleCommandRequest : IRequest<DeleteRoleCommandResponse>
    {
        public Guid RoleId { get; set; }

        public DeleteRoleCommandRequest()
        {

        }

        public DeleteRoleCommandRequest(Guid roleId)
        {
            RoleId = roleId;
        }
    }
}
