using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Security.Authorization;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Roles.Update
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest, UpdateRoleCommandResponse>
    {
        private readonly IRoleCommandRepository _roleCommandRepository;
        private readonly IRoleQueryRepository _roleQueryRepository;
        private readonly RoleBusinessRules _roleBusinessRules;
        private readonly IMapper _mapper;

        public UpdateRoleCommandHandler(IRoleCommandRepository roleCommandRepository, IRoleQueryRepository roleQueryRepository, RoleBusinessRules roleBusinessRules, IMapper mapper)
        {
            _roleCommandRepository = roleCommandRepository;
            _roleQueryRepository = roleQueryRepository;
            _roleBusinessRules = roleBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var role = await _roleQueryRepository.GetByIdAsync(request.RoleId);

            await _roleBusinessRules.NullCheck(role);

            _mapper.Map(request, role);

            _roleCommandRepository.Update(role);

            await _roleCommandRepository.SaveChangesAsync();

            var roleDto = _mapper.Map<RoleDto>(role);

            return new UpdateRoleCommandResponse(new SuccessfulContentResponse<RoleDto>(roleDto, ResponseTitles.Success, ResponseMessages.RoleUpdated, System.Net.HttpStatusCode.OK));
        }
    }
}
