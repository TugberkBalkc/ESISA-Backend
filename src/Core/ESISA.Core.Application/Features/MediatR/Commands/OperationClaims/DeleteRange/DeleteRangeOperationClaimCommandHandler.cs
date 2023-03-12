using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.OperationClaims.DeleteRange
{
    public class DeleteRangeOperationClaimCommandHandler : IRequestHandler<DeleteRangeOperationClaimCommandRequest, DeleteRangeOperationClaimCommandResponse>
    {
        private readonly IOperationClaimCommandRepository _operationClaimCommandRepository;
        private readonly IOperationClaimQueryRepository _operationClaimQueryRepository;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public DeleteRangeOperationClaimCommandHandler
            (IOperationClaimCommandRepository operationClaimCommandRepository, IOperationClaimQueryRepository operationClaimQueryRepository,
             OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimCommandRepository = operationClaimCommandRepository;
            _operationClaimQueryRepository = operationClaimQueryRepository;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<DeleteRangeOperationClaimCommandResponse> Handle(DeleteRangeOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            var operationClaimsToCheck = new List<OperationClaim>();

            foreach (var id in request.OperationClaimIds)
            {
                operationClaimsToCheck.Add(await _operationClaimQueryRepository.GetByIdAsync(id));
            }
        
            await _operationClaimBusinessRules.NullCheck(operationClaimsToCheck);

            await _operationClaimCommandRepository.DeleteRangeAsync(request.OperationClaimIds);

            await _operationClaimCommandRepository.SaveChangesAsync();

            return new DeleteRangeOperationClaimCommandResponse(new SuccessfulContentResponse<bool>(true, ResponseTitles.Success, ResponseMessages.OperationClaimsDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
