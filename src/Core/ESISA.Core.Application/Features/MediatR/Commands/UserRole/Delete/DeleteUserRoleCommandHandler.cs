using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.UserRoles.Delete
{
    public class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommandRequest, DeleteUserRoleCommandResponse>
    {
        private readonly IUserRoleQueryRepository _userRoleQueryRepository;
        private readonly IUserRoleCommandRepository _userRoleCommandRepository;
        private readonly UserRoleBusinessRules _userRoleBusinessRules;

        private readonly IUserQueryRepository _userQueryRepository;
        private readonly UserBusinessRules _userBusinessRules;

        private readonly IRoleQueryRepository _roleQueryRepository;
        private readonly RoleBusinessRules _roleBusinessRules;

        public DeleteUserRoleCommandHandler(IUserRoleQueryRepository userRoleQueryRepository, IUserRoleCommandRepository userRoleCommandRepository, UserRoleBusinessRules userRoleBusinessRules, IUserQueryRepository userQueryRepository, UserBusinessRules userBusinessRules, IRoleQueryRepository roleQueryRepository, RoleBusinessRules roleBusinessRules)
        {
            _userRoleQueryRepository = userRoleQueryRepository;
            _userRoleCommandRepository = userRoleCommandRepository;
            _userRoleBusinessRules = userRoleBusinessRules;
            _userQueryRepository = userQueryRepository;
            _userBusinessRules = userBusinessRules;
            _roleQueryRepository = roleQueryRepository;
            _roleBusinessRules = roleBusinessRules;
        }

        public async Task<DeleteUserRoleCommandResponse> Handle(DeleteUserRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userQueryRepository.GetByIdAsync(request.UserId);

            await _userBusinessRules.NullCheck(user);

            var role = await _roleQueryRepository.GetByIdAsync(request.RoleId);

            await _roleBusinessRules.NullCheck(role);

            var userRole = await _userRoleQueryRepository.GetSingleAsync(e => e.UserId == request.UserId && e.RoleId == request.RoleId);

            await _userRoleBusinessRules.NullCheck(userRole);

            await _userRoleCommandRepository.DeleteAsync(userRole.Id);
            await _userRoleCommandRepository.SaveChangesAsync();

            return new DeleteUserRoleCommandResponse(new SuccessfulContentResponse<Guid>(userRole.Id, ResponseTitles.Success, ResponseMessages.RoleRemovedInUser, System.Net.HttpStatusCode.OK));
        }
    }
}
