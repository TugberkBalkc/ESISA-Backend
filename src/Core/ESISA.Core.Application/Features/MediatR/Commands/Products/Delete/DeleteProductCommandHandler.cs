using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Products.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandRespone>
    {
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly ProductBusinessRules _productBusinessRules;

        public DeleteProductCommandHandler(IProductCommandRepository productCommandRepository, ProductBusinessRules productBusinessRules)
        {
            _productCommandRepository = productCommandRepository;
            _productBusinessRules = productBusinessRules;
        }

        public async Task<DeleteProductCommandRespone> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productBusinessRules.NullCheckByProductId(request.ProductId);

            await _productCommandRepository.DeleteAsync(request.ProductId);

            await _productCommandRepository.SaveChangesAsync();

            return new DeleteProductCommandRespone(new SuccessfulContentResponse<Guid>(request.ProductId, ResponseTitles.Success, ResponseMessages.ProductDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
