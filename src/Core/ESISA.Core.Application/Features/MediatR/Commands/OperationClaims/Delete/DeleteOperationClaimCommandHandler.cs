using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.OperationClaims.Delete
{
    public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommandRequest, DeleteOperationClaimCommandResponse>
    {
        private readonly IOperationClaimCommandRepository _operationClaimCommandRepository;
        private readonly IOperationClaimQueryRepository _operationClaimQueryRepository;
        private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

        public DeleteOperationClaimCommandHandler(IOperationClaimCommandRepository operationClaimCommandRepository, IOperationClaimQueryRepository operationClaimQueryRepository, OperationClaimBusinessRules operationClaimBusinessRules)
        {
            _operationClaimCommandRepository = operationClaimCommandRepository;
            _operationClaimQueryRepository = operationClaimQueryRepository;
            _operationClaimBusinessRules = operationClaimBusinessRules;
        }

        public async Task<DeleteOperationClaimCommandResponse> Handle(DeleteOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            var operationClaimToCheck = await _operationClaimQueryRepository.GetByIdAsync(request.OperationClaimId);

            await _operationClaimBusinessRules.NullCheck(operationClaimToCheck);

            await _operationClaimCommandRepository.DeleteAsync(request.OperationClaimId);

            await _operationClaimCommandRepository.SaveChangesAsync();

            return new DeleteOperationClaimCommandResponse(new SuccessfulContentResponse<Guid>(request.OperationClaimId, ResponseTitles.Success, ResponseMessages.OperationClaimDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
