using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Product;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.Products.GetDetailsByNameContains
{
    public class GetDetailsByNameContainsProductQueryHandler : IRequestHandler<GetDetailsByNameContainsProductQueryRequest, GetDetailsByNameContainsProductQueryResponse>
    {
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly IMapper _mapper;

        public GetDetailsByNameContainsProductQueryHandler(IProductQueryRepository productQueryRepository, IMapper mapper)
        {
            _productQueryRepository = productQueryRepository;
            _mapper = mapper;
        }

        public async Task<GetDetailsByNameContainsProductQueryResponse> Handle(GetDetailsByNameContainsProductQueryRequest request, CancellationToken cancellationToken)
        {
            var productDtos = _productQueryRepository.GetWhere(predicate: e => e.Name.Contains(request.ProductNameSearchKey)).Select(e => _mapper.Map<ProductDetailsDto>(e));

            var paginate = productDtos.ToPaginate<ProductDetailsDto>(request.PageIndex, request.PageSize);

            return new GetDetailsByNameContainsProductQueryResponse(new SuccessfulContentResponse<IPaginate<ProductDetailsDto>>(paginate, ResponseTitles.Success, ResponseMessages.ProductsListed, System.Net.HttpStatusCode.OK));
        }
    }
}
