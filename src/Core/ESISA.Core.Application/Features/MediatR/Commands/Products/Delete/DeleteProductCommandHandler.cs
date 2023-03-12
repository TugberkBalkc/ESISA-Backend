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
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly ProductBusinessRules _productBusinessRules;

        public DeleteProductCommandHandler(IProductCommandRepository productCommandRepository, IProductQueryRepository productQueryRepository, ProductBusinessRules productBusinessRules)
        {
            _productCommandRepository = productCommandRepository;
            _productQueryRepository = productQueryRepository;
            _productBusinessRules = productBusinessRules;
        }

        public async Task<DeleteProductCommandRespone> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var productToCheck = await _productQueryRepository.GetByIdAsync(request.ProductId); ;

            await _productBusinessRules.NullCheck(productToCheck);

            await _productCommandRepository.DeleteAsync(request.ProductId);

            await _productCommandRepository.SaveChangesAsync();

            return new DeleteProductCommandRespone(new SuccessfulContentResponse<Guid>(request.ProductId, ResponseTitles.Success, ResponseMessages.ProductDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
