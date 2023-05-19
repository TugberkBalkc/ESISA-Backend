using ESISA.Core.Application.Dtos.Security.Authorization;
using ESISA.Core.Application.Utilities.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.UserRoles.Create
{
    public class CreateUserRoleCommandRequest : IRequest<CreateUserRoleCommandResponse>
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public CreateUserRoleCommandRequest()
        {

        }

        public CreateUserRoleCommandRequest(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}
