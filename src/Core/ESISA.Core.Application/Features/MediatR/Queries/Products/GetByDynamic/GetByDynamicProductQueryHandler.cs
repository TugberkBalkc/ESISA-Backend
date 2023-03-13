using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Product;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.Products.GetByDynamic
{
    public class GetByDynamicProductQueryHandler : IRequestHandler<GetByDynamicProductQueryRequest, GetByDynamicProductQueryResponse>
    {
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly IMapper _mapper;

        public GetByDynamicProductQueryHandler(IProductQueryRepository productQueryRepository, IMapper mapper)
        {
            _productQueryRepository = productQueryRepository;
            _mapper = mapper;
        }

        public async Task<GetByDynamicProductQueryResponse> Handle(GetByDynamicProductQueryRequest request, CancellationToken cancellationToken)
        {
            var products = _productQueryRepository.GetByDynamicQuery(request.DynamicQuery).Select(p=>_mapper.Map<ProductDetailsDto>(p));

            var paginate = products.ToPaginate<ProductDetailsDto>(request.PageIndex, request.PageSize);

            return new GetByDynamicProductQueryResponse(new SuccessfulContentResponse<IPaginate<ProductDetailsDto>>(paginate, ResponseTitles.Success, ResponseMessages.ProductListed, System.Net.HttpStatusCode.OK));
        }
    }
}
