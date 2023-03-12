using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Roles.AddOperationClaim
{
    public class AddOperationClaimToRoleCommandHandler : IRequestHandler<AddOperationClaimToRoleCommandRequest, AddOperationClaimToRoleCommandResponse>
    {
        private readonly IRoleOperationClaimCommandRepository _roleOperationClaimCommandRepository;
        private readonly IRoleOperationClaimQueryRepository _roleOperationClaimQueryRepository;
        private readonly RoleOperationClaimBusinessRules _roleOperationClaimBusinessRules;
        private readonly IRoleQueryRepository _roleQueryRepository;
        private readonly IOperationClaimQueryRepository _operationClaimQueryRepository;
        private readonly IMapper _mapper;

        public AddOperationClaimToRoleCommandHandler
            (IRoleOperationClaimCommandRepository roleOperationClaimCommandRepository, IRoleOperationClaimQueryRepository roleOperationClaimQueryRepository,
             RoleOperationClaimBusinessRules roleOperationClaimBusinessRules, IRoleQueryRepository roleQueryRepository, IOperationClaimQueryRepository operationClaimQueryRepository,
             IMapper mapper)
        {
            _roleOperationClaimCommandRepository = roleOperationClaimCommandRepository;
            _roleOperationClaimQueryRepository = roleOperationClaimQueryRepository;
            _roleOperationClaimBusinessRules = roleOperationClaimBusinessRules;
            _roleQueryRepository = roleQueryRepository;
            _operationClaimQueryRepository = operationClaimQueryRepository;
            _mapper = mapper;
        }

        public async Task<AddOperationClaimToRoleCommandResponse> Handle(AddOperationClaimToRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var roleToCheck = await _roleQueryRepository.GetByIdAsync(request.RoleId);

            await _roleOperationClaimBusinessRules.NullCheck(roleToCheck);

            var operationClaimToCheck = await _operationClaimQueryRepository.GetByIdAsync(request.OperationClaimId);

            await _roleOperationClaimBusinessRules.NullCheck(operationClaimToCheck);

            var roleOperationClaimToCheck = await _roleOperationClaimQueryRepository.GetSingleAsync(e => e.RoleId == request.RoleId && e.OperationClaimId == request.OperationClaimId);

            await _roleOperationClaimBusinessRules.ExistsCheck(roleOperationClaimToCheck);

            var roleOperationClaim = _mapper.Map<RoleOperationClaim>(request);

            await _roleOperationClaimCommandRepository.AddAsync(roleOperationClaim);

            await _roleOperationClaimCommandRepository.SaveChangesAsync();

            var roleOperationClaimDto = _mapper.Map<RoleOperationClaimDto>(roleOperationClaim);

            return new AddOperationClaimToRoleCommandResponse(new SuccessfulContentResponse<RoleOperationClaimDto>(roleOperationClaimDto, ResponseTitles.Success, ResponseMessages.RoleOperationClaimCreated, System.Net.HttpStatusCode.Created));
        }
    }
}
