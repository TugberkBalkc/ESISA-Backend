using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Security.Authorization;
using ESISA.Core.Application.Extensions;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.OperationClaims.Create
{
    public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommandRequest, CreateOperationClaimCommandResponse>
    {
        private readonly IOperationClaimCommandRepository _operationClaimCommandRepository;
        private readonly IOperationClaimQueryRepository _operationClaimQueryRepository;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;
        private readonly IMapper _mapper;
        public CreateOperationClaimCommandHandler
            (IOperationClaimCommandRepository operationClaimCommandRepository, IOperationClaimQueryRepository operationClaimQueryRepository,
             OperationClaimBusinessRules operationClaimBusinessRules, IMapper mapper)
        {
            _operationClaimCommandRepository = operationClaimCommandRepository;
            _operationClaimQueryRepository = operationClaimQueryRepository;
            _operationClaimBusinessRules = operationClaimBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreateOperationClaimCommandResponse> Handle(CreateOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            var operationClaimToCheck = await _operationClaimQueryRepository.GetSingleAsync(e => e.ClaimName == request.OperationClaimName);

            await _operationClaimBusinessRules.ExistsCheck(operationClaimToCheck);

            var operationClaim = _mapper.Map<OperationClaim>(request);

            await _operationClaimCommandRepository.AddAsync(operationClaim);

            await _operationClaimCommandRepository.SaveChangesAsync();

            var operationClaimDto = _mapper.Map<OperationClaimDto>(operationClaim);

            return new CreateOperationClaimCommandResponse(new SuccessfulContentResponse<OperationClaimDto>(operationClaimDto, ResponseTitles.Success, ResponseMessages.OperationClaimCreated, System.Net.HttpStatusCode.Created));
        }
    }
}
