using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Roles.DeleteRange
{
    public class DeleteRangeRoleCommandHandler : IRequestHandler<DeleteRangeRoleCommandRequest, DeleteRangeRoleCommandResponse>
    {
        private readonly IRoleCommandRepository _roleCommandRepository;
        private readonly IRoleQueryRepository _roleQueryRepository;
        private readonly RoleBusinessRules _roleBusinessRules;

        public DeleteRangeRoleCommandHandler
            (IRoleCommandRepository roleCommandRepository, IRoleQueryRepository roleQueryRepository,
             RoleBusinessRules roleBusinessRules)
        {
            _roleCommandRepository = roleCommandRepository;
            _roleQueryRepository = roleQueryRepository;
            _roleBusinessRules = roleBusinessRules;
        }

        public async Task<DeleteRangeRoleCommandResponse> Handle(DeleteRangeRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var rolesToCheck = new List<Role>();

            foreach (var id in request.RoleIds)
            {
                rolesToCheck.Add(await _roleQueryRepository.GetByIdAsync(id));
            }

            await _roleBusinessRules.NullCheck(rolesToCheck);

            await _roleCommandRepository.DeleteRangeAsync(request.RoleIds);

            await _roleCommandRepository.SaveChangesAsync();

            return new DeleteRangeRoleCommandResponse(new SuccessfulContentResponse<bool>(true, ResponseTitles.Success, ResponseMessages.RolesDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
