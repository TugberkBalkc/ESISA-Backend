using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Security.Authorization;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.UserRoles.Create
{
    public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommandRequest, CreateUserRoleCommandResponse>
    {
        private readonly IUserRoleCommandRepository _userRoleCommandRepository;
        private readonly IUserRoleQueryRepository _userRoleQueryRepository;
        private readonly UserRoleBusinessRules _userRoleBusinessRules;

        private readonly IRoleQueryRepository _roleQueryRepository;
        private readonly RoleBusinessRules _roleBusinessRules;

        private readonly IUserQueryRepository _userQueryRepository;
        private readonly UserBusinessRules _userBusinessRules;

        private readonly IMapper _mapper;

        public CreateUserRoleCommandHandler(IRoleQueryRepository roleQueryRepository, RoleBusinessRules roleBusinessRules, IUserQueryRepository userQueryRepository, UserBusinessRules userBusinessRules, IUserCommandRepository userCommandRepository, IUserRoleCommandRepository userRoleCommandRepository, IUserRoleQueryRepository userRoleQueryRepository, UserRoleBusinessRules userRoleBusinessRules, IMapper mapper)
        {
            _userQueryRepository = userQueryRepository;
            _userBusinessRules = userBusinessRules;

            _roleQueryRepository = roleQueryRepository;
            _roleBusinessRules = roleBusinessRules;

            _userRoleCommandRepository = userRoleCommandRepository;
            _userRoleQueryRepository = userRoleQueryRepository;
            _userRoleBusinessRules = userRoleBusinessRules; 

            _mapper = mapper;
        }

        public async Task<CreateUserRoleCommandResponse> Handle(CreateUserRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userQueryRepository.GetByIdAsync(request.UserId);

            await _userBusinessRules.NullCheck(user);

            var role = await _roleQueryRepository.GetByIdAsync(request.RoleId);

            await _roleBusinessRules.NullCheck(role);

            var userRoleToCheck = await _userRoleQueryRepository.GetSingleAsync(e => e.UserId == request.UserId && e.RoleId == request.RoleId);

            await _userRoleBusinessRules.ExistsCheck(userRoleToCheck);

            var userRole = _mapper.Map<UserRole>(request);

            await _userRoleCommandRepository.AddAsync(userRole);
            await _userRoleCommandRepository.SaveChangesAsync();

            var userRoleDto = _mapper.Map<UserRoleDto>(userRole);

            return new CreateUserRoleCommandResponse(new SuccessfulContentResponse<UserRoleDto>(userRoleDto, ResponseTitles.Success, ResponseMessages.RoleAddedToUser, System.Net.HttpStatusCode.Created));

        }
    }
}
