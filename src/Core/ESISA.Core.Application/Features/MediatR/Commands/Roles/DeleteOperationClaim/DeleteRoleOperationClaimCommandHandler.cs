using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Roles.DeleteOperationClaim
{
    public class DeleteRoleOperationClaimCommandHandler : IRequestHandler<DeleteRoleOperationClaimCommandRequest, DeleteRoleOperationClaimCommandResponse>
    {
        private readonly IRoleOperationClaimCommandRepository _roleOperationClaimCommandRepository;
        private readonly IRoleOperationClaimQueryRepository _roleOperationClaimQueryRepository;
        private readonly RoleOperationClaimBusinessRules _roleOperationClaimBusinessRules;

        public DeleteRoleOperationClaimCommandHandler
            (IRoleOperationClaimCommandRepository roleOperationClaimCommandRepository, IRoleOperationClaimQueryRepository roleOperationClaimQueryRepository, 
             RoleOperationClaimBusinessRules roleOperationClaimBusinessRules)
        {
            _roleOperationClaimCommandRepository = roleOperationClaimCommandRepository;
            _roleOperationClaimQueryRepository = roleOperationClaimQueryRepository;
            _roleOperationClaimBusinessRules = roleOperationClaimBusinessRules;
        }

        public async Task<DeleteRoleOperationClaimCommandResponse> Handle(DeleteRoleOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            var roleOperationClaimToCheck = await _roleOperationClaimQueryRepository.GetByIdAsync(request.RoleOperationClaimId);

            await _roleOperationClaimBusinessRules.NullCheck(roleOperationClaimToCheck);

            await _roleOperationClaimCommandRepository.DeleteAsync(request.RoleOperationClaimId);

            await _roleOperationClaimCommandRepository.SaveChangesAsync();

            return new DeleteRoleOperationClaimCommandResponse(new SuccessfulContentResponse<Guid>(request.RoleOperationClaimId, ResponseTitles.Success, ResponseMessages.RoleOperationCalimDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
