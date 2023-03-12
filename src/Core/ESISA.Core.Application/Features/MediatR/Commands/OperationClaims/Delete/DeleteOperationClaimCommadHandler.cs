using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.OperationClaims.Delete
{
    public class DeleteOperationClaimCommadHandler : IRequestHandler<DeleteOperationClaimCommadRequest, DeleteOperationClaimCommadResponse>
    {
        private readonly IOperationClaimCommandRepository _operationClaimCommandRepository;
        private readonly IOperationClaimQueryRepository _operationClaimQueryRepository;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public DeleteOperationClaimCommadHandler(IOperationClaimCommandRepository operationClaimCommandRepository, IOperationClaimQueryRepository operationClaimQueryRepository, OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimCommandRepository = operationClaimCommandRepository;
            _operationClaimQueryRepository = operationClaimQueryRepository;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<DeleteOperationClaimCommadResponse> Handle(DeleteOperationClaimCommadRequest request, CancellationToken cancellationToken)
        {
            var operationClaimToCheck = await _operationClaimQueryRepository.GetByIdAsync(request.OperationClaimId);

            await _operationClaimBusinessRules.NullCheck(operationClaimToCheck);

            await _operationClaimCommandRepository.DeleteAsync(request.OperationClaimId);

            await _operationClaimCommandRepository.SaveChangesAsync();

            return new DeleteOperationClaimCommadResponse(new SuccessfulContentResponse<Guid>(request.OperationClaimId, ResponseTitles.Success, ResponseMessages.OperationClaimDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
