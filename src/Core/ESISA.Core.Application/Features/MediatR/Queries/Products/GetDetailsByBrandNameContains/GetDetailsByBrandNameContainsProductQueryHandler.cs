using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Product;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.Products.GetDetailsByBrandContains
{
    public class GetDetailsByBrandNameContainsProductQueryHandler : IRequestHandler<GetDetailsByBrandNameContainsProductQueryRequest, GetDetailsByBrandNameContainsProductQueryResponse>
    {
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly IMapper _mapper;

        public GetDetailsByBrandNameContainsProductQueryHandler(IProductQueryRepository productQueryRepository, IMapper mapper)
        {
            _productQueryRepository = productQueryRepository;
            _mapper = mapper;
        }

        public async Task<GetDetailsByBrandNameContainsProductQueryResponse> Handle(GetDetailsByBrandNameContainsProductQueryRequest request, CancellationToken cancellationToken)
        {
            var productDtos = _productQueryRepository.GetWhere(predicate: e => e.Brand.Name.Contains(request.BrandNameSearchKey), false, null, e => e.Brand).Select(e=>_mapper.Map<ProductDetailsDto>(e));

            var paginate = productDtos.ToPaginate<ProductDetailsDto>(request.PageIndex, request.PageSize);

            return new GetDetailsByBrandNameContainsProductQueryResponse(new SuccessfulContentResponse<IPaginate<ProductDetailsDto>>(paginate, ResponseTitles.Success, ResponseMessages.ProductsListed, System.Net.HttpStatusCode.OK));
        }
    }
}
