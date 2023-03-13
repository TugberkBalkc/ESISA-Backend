using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Product;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.Products.GetDetailsById
{
    public class GetDetailsByIdProductQueryHandler : IRequestHandler<GetDetailsByIdProductQueryRequest, GetDetailsByIdProductQueryResponse>
    {
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly IMapper _mapper;

        public GetDetailsByIdProductQueryHandler(IProductQueryRepository productQueryRepository, IMapper mapper)
        {
            _productQueryRepository = productQueryRepository;
            _mapper = mapper;
        }

        public async Task<GetDetailsByIdProductQueryResponse> Handle(GetDetailsByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _productQueryRepository.GetByIdAsync(request.ProductId, false, e=>e.Brand, e=>e.Category);

            var productDto = _mapper.Map<ProductDetailsDto>(product);

            return new GetDetailsByIdProductQueryResponse(new SuccessfulContentResponse<ProductDetailsDto>(productDto, ResponseTitles.Success, ResponseMessages.ProductListed, System.Net.HttpStatusCode.OK));
        }
    }
}
