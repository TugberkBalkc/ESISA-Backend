using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Product;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.Products.GetProductDetailsByDynamic
{
    public class GetProductDetailsByDynamicQueryHandler : IRequestHandler<GetProductDetailsByDynamicQueryRequest, GetProductDetailsByDynamicQueryResponse>
    {
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly IMapper _mapper;

        public GetProductDetailsByDynamicQueryHandler(IProductQueryRepository productQueryRepository, ProductBusinessRules productBusinessRules, IMapper mapper)
        {
            _productQueryRepository = productQueryRepository;
            _productBusinessRules = productBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetProductDetailsByDynamicQueryResponse> Handle(GetProductDetailsByDynamicQueryRequest request, CancellationToken cancellationToken)
        {
            var productDetailsDtos = _productQueryRepository.GetByDynamicQuery(request.DynamicQuery, null, false, e=>e.Brand, e=>e.Category).Select(p=>_mapper.Map<ProductDetailsDto>(p));

            await _productBusinessRules.NullCheck(productDetailsDtos);

            var paginate = productDetailsDtos.ToPaginate<ProductDetailsDto>(request.PageIndex, request.PageSize);

            return new GetProductDetailsByDynamicQueryResponse(new SuccessfulContentResponse<IPaginate<ProductDetailsDto>>(paginate, ResponseTitles.Success, ResponseMessages.ProductListed, System.Net.HttpStatusCode.OK));
        }
    }
}
