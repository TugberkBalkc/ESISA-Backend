using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Product;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.Products.GetAllDetails
{
    public class GetAllDetailsProductQueryHandler : IRequestHandler<GetAllDetailsProductQueryRequest, GetAllDetailsProductQueryResponse>
    {
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly IMapper _mapper;

        public GetAllDetailsProductQueryHandler(IProductQueryRepository productQueryRepository, IMapper mapper)
        {
            _productQueryRepository = productQueryRepository;
            _mapper = mapper;
        }

        public async Task<GetAllDetailsProductQueryResponse> Handle(GetAllDetailsProductQueryRequest request, CancellationToken cancellationToken)
        {
            var productDetailsDtos = _productQueryRepository.GetAll(false, null, e => e.Brand, e => e.Category).Select(e => _mapper.Map<ProductDetailsDto>(e));

            var paginate = productDetailsDtos.ToPaginate<ProductDetailsDto>(request.PageIndex, request.PageSize);

            return new GetAllDetailsProductQueryResponse(new SuccessfulContentResponse<IPaginate<ProductDetailsDto>>(paginate, ResponseTitles.Success, ResponseMessages.ProductsListed, System.Net.HttpStatusCode.OK));
        }
    }
}
