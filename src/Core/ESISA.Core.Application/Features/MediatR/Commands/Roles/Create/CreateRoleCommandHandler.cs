using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Security.Authorization;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Roles.Create
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, CreateRoleCommandResponse>
    {
        private readonly IRoleCommandRepository _roleCommandRepository;
        private readonly IRoleQueryRepository _roleQueryRepository;
        private readonly RoleBusinessRules _roleBusinessRules;
        private readonly IMapper _mapper;

        public CreateRoleCommandHandler(IRoleCommandRepository roleCommandRepository, IRoleQueryRepository roleQueryRepository,  RoleBusinessRules roleBusinessRules, IMapper mapper)
        {
            _roleCommandRepository = roleCommandRepository;
            _roleQueryRepository = roleQueryRepository;
            _roleBusinessRules = roleBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var roleToCheck = await _roleQueryRepository.GetSingleAsync(e => e.Name == request.RoleName);

            await _roleBusinessRules.ExistsCheck(roleToCheck);

            var role = _mapper.Map<Role>(request);

            await _roleCommandRepository.AddAsync(role);

            await _roleCommandRepository.SaveChangesAsync();

            var roleDto = _mapper.Map<RoleDto>(role);

            return new CreateRoleCommandResponse(new SuccessfulContentResponse<RoleDto>(roleDto, ResponseTitles.Success, ResponseMessages.RoleCreated, System.Net.HttpStatusCode.OK));
        }
    }
}
