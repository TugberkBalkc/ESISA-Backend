using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Product;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.Products.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
    {
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductQueryRepository productQueryRepository, ProductBusinessRules productBusinessRules, IMapper mapper)
        {
            _productQueryRepository = productQueryRepository;
            _productBusinessRules = productBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var productDtos = _productQueryRepository.GetAll().Select(e=>_mapper.Map<ProductDto>(e));

            await _productBusinessRules.NullCheck(productDtos);

            var paginate = productDtos.ToPaginate<ProductDto>(request.PageIndex, request.PageSize);

            return new GetAllProductsQueryResponse(new SuccessfulContentResponse<IPaginate<ProductDto>>(paginate, ResponseTitles.Success, ResponseMessages.ProductsListed, System.Net.HttpStatusCode.OK));
        }
    }
}
