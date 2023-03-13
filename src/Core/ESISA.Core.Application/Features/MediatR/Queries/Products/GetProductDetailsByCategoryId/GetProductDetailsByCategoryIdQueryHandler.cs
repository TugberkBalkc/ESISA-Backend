using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Product;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.Products.GetProductDetailsByCategoryId
{
    public class GetProductDetailsByCategoryIdQueryHandler : IRequestHandler<GetProductDetailsByCategoryIdQueryRequest, GetProductDetailsByCategoryIdQueryResponse>
    {
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly IMapper _mapper;

        public GetProductDetailsByCategoryIdQueryHandler(IProductQueryRepository productQueryRepository, ProductBusinessRules productBusinessRules, IMapper mapper)
        {
            _productQueryRepository = productQueryRepository;
            _productBusinessRules = productBusinessRules; 
            _mapper = mapper;
        }

        public async Task<GetProductDetailsByCategoryIdQueryResponse> Handle(GetProductDetailsByCategoryIdQueryRequest request, CancellationToken cancellationToken)
        {
            var productDetailsDtos = _productQueryRepository.GetWhere(e => e.CategoryId == request.CategoryId, false, null, e => e.Brand, e => e.Category).Select(e => _mapper.Map<ProductDetailsDto>(e));

            await _productBusinessRules.NullCheck(productDetailsDtos);

            var paginate = productDetailsDtos.ToPaginate<ProductDetailsDto>(request.PageIndex, request.PageSize);

            return new GetProductDetailsByCategoryIdQueryResponse(new SuccessfulContentResponse<IPaginate<ProductDetailsDto>>(paginate, ResponseTitles.Success, ResponseMessages.ProductListed, System.Net.HttpStatusCode.OK));
        }
    }
}
