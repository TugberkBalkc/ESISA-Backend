using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteProductDemand
{
    public class DeleteProductDemandCommandHandler : IRequestHandler<DeleteProductDemandCommandRequest, DeleteProductDemandCommandResponse>
    {
        private readonly IProductDemandCommandRepository _productDemandCommandRepository;
        private readonly ProductDemandBusinessRules _productDemandBusinessRules;

        public DeleteProductDemandCommandHandler(IProductDemandCommandRepository productDemandCommandRepository, ProductDemandBusinessRules productDemandBusinessRules)
        {
            _productDemandCommandRepository = productDemandCommandRepository;
            _productDemandBusinessRules = productDemandBusinessRules;
        }

        public async Task<DeleteProductDemandCommandResponse> Handle(DeleteProductDemandCommandRequest request, CancellationToken cancellationToken)
        {
            await _productDemandBusinessRules.CheckIfProductDemandNull(request.ProductDemandId);

            await _productDemandCommandRepository.DeleteAsync(request.ProductDemandId);

            await _productDemandCommandRepository.SaveChangesAsync();

            return new DeleteProductDemandCommandResponse(new SuccessfulContentResponse<Guid>(request.ProductDemandId, ResponseTitles.Success, ResponseMessages.DemandDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
