using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Security.Authorization;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.OperationClaims.Update
{
    public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommandRequest, UpdateOperationClaimCommandResponse>
    {
        private readonly IOperationClaimCommandRepository _operationClaimCommandRepository;
        private readonly IOperationClaimQueryRepository _operationClaimQueryRepository;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;
        private readonly IMapper _mapper;

        public UpdateOperationClaimCommandHandler
            (IOperationClaimCommandRepository operationClaimCommandRepository, IOperationClaimQueryRepository operationClaimQueryRepository, 
             OperationClaimBusinessRules operationClaimBusinessRules, IMapper mapper)
        {
            _operationClaimCommandRepository = operationClaimCommandRepository;
            _operationClaimQueryRepository = operationClaimQueryRepository;
            _operationClaimBusinessRules = operationClaimBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdateOperationClaimCommandResponse> Handle(UpdateOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            var operationClaim = await _operationClaimQueryRepository.GetByIdAsync(request.OperationClaimId);

            await _operationClaimBusinessRules.NullCheck(operationClaim);

            _mapper.Map(request, operationClaim);

            _operationClaimCommandRepository.Update(operationClaim);

            await _operationClaimCommandRepository.SaveChangesAsync();

            var operationClaimDto = _mapper.Map<OperationClaimDto>(operationClaim);

            return new UpdateOperationClaimCommandResponse(new SuccessfulContentResponse<OperationClaimDto>(operationClaimDto, ResponseTitles.Success, ResponseMessages.OperationClaimUpdated, System.Net.HttpStatusCode.OK));
        }
    }
} 
