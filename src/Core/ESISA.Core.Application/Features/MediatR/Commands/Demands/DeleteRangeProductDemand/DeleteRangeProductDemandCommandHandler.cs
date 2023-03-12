using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteRangeProductDemand
{
    public class DeleteRangeProductDemandCommandHandler : IRequestHandler<DeleteRangeProductDemandCommandRequest, DeleteRangeProductDemandCommandResponse>
    {
        private readonly IProductDemandCommandRepository _productDemandCommandRepository;
        private readonly IProductDemandQueryRepository _productDemandQueryRepository;
        private readonly ProductDemandBusinessRules _productDemandBusinessRules;

        public DeleteRangeProductDemandCommandHandler
            (IProductDemandCommandRepository productDemandCommandRepository, IProductDemandQueryRepository productDemandQueryRepository, ProductDemandBusinessRules productDemandBusinessRules)
        {
            _productDemandCommandRepository = productDemandCommandRepository;
            _productDemandQueryRepository = productDemandQueryRepository;
            _productDemandBusinessRules = productDemandBusinessRules;
        }

        public async Task<DeleteRangeProductDemandCommandResponse> Handle(DeleteRangeProductDemandCommandRequest request, CancellationToken cancellationToken)
        {
            var productDemandsToCheck = new List<ProductDemand>();

            foreach (var id in request.ProductDemandIds)
            {
                productDemandsToCheck.Add(await _productDemandQueryRepository.GetByIdAsync(id));
            }

            await _productDemandBusinessRules.NullCheck(productDemandsToCheck);

            await _productDemandCommandRepository.DeleteRangeAsync(request.ProductDemandIds);

            await _productDemandCommandRepository.SaveChangesAsync();

            return new DeleteRangeProductDemandCommandResponse(new SuccessfulContentResponse<bool>(true, ResponseTitles.Success, ResponseMessages.DemandsDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
