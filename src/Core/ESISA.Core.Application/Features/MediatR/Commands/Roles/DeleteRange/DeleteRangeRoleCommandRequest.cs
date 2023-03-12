using ESISA.Core.Application.Features.MediatR.Commands.Products.DeleteRange;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Roles.DeleteRange
{
    public class DeleteRangeRoleCommandRequest : IRequest<DeleteRangeRoleCommandResponse>
    {
        public Guid[] RoleIds { get; set; }

        public DeleteRangeRoleCommandRequest()
        {

        }

        public DeleteRangeRoleCommandRequest(Guid[] roleIds)
        {
            RoleIds = roleIds;
        }
    }
}
