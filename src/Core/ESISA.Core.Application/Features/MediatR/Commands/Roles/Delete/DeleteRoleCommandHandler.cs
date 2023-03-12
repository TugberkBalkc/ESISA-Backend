using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Roles.Delete
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, DeleteRoleCommandResponse>
    {
        private readonly IRoleCommandRepository _roleCommandRepository;
        private readonly IRoleQueryRepository _roleQueryRepository;
        private readonly RoleBusinessRules _roleBusinessRules;

        public DeleteRoleCommandHandler(IRoleCommandRepository roleCommandRepository, IRoleQueryRepository roleQueryRepository, RoleBusinessRules roleBusinessRules)
        {
            _roleCommandRepository = roleCommandRepository;
            _roleQueryRepository = roleQueryRepository;
            _roleBusinessRules = roleBusinessRules;
        }

        public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var roleToCheck = _roleQueryRepository.GetSingleAsync(e=>e.Id== request.RoleId);

            await _roleBusinessRules.NullCheck(roleToCheck);

            await _roleCommandRepository.DeleteAsync(request.RoleId);

            await _roleCommandRepository.SaveChangesAsync();

            return new DeleteRoleCommandResponse(new SuccessfulContentResponse<Guid>(request.RoleId, ResponseTitles.Success, ResponseMessages.RoleDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
