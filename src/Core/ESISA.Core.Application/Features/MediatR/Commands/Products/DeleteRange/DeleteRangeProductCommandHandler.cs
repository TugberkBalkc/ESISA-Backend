using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Products.DeleteRange
{
    public class DeleteRangeProductCommandHandler : IRequestHandler<DeleteRangeProductCommandRequest, DeleteRangeProductCommandResponse>
    {
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly ProductBusinessRules _productBusinessRules;

        public DeleteRangeProductCommandHandler(IProductCommandRepository productCommandRepository, IProductQueryRepository productQueryRepository, ProductBusinessRules productBusinessRules)
        {
            _productCommandRepository = productCommandRepository;
            _productQueryRepository = productQueryRepository;
            _productBusinessRules = productBusinessRules;
        }

        public async Task<DeleteRangeProductCommandResponse> Handle(DeleteRangeProductCommandRequest request, CancellationToken cancellationToken)
        {
            var productsToCheck = new List<Product>();

            foreach (var id in request.ProductIds)
            {
                productsToCheck.Add(await _productQueryRepository.GetByIdAsync(id));
            }

            await _productBusinessRules.NullCheck(productsToCheck);

            await _productCommandRepository.DeleteRangeAsync(request.ProductIds);

            await _productCommandRepository.SaveChangesAsync();

            return new DeleteRangeProductCommandResponse(new SuccessfulContentResponse<bool>(true, ResponseTitles.Success, ResponseMessages.ProductsDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
