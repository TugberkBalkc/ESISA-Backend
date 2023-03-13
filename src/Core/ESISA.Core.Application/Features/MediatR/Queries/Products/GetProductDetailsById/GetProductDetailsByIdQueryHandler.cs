using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Product;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.Products.GetProductDetailsById
{
    public class GetProductDetailsByIdQueryHandler : IRequestHandler<GetProductDetailsByIdQueryRequest, GetProductDetailsByIdQueryResponse>
    {
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly IMapper _mapper;

        public GetProductDetailsByIdQueryHandler(IProductQueryRepository productQueryRepository, ProductBusinessRules productBusinessRules, IMapper mapper)
        {
            _productQueryRepository = productQueryRepository;
            _productBusinessRules = productBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetProductDetailsByIdQueryResponse> Handle(GetProductDetailsByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _productQueryRepository.GetByIdAsync(request.ProductId, false, e => e.Brand, e => e.Category);

            await _productBusinessRules.NullCheck(product);

            var productDetailsDto = _mapper.Map<ProductDetailsDto>(product);

            return new GetProductDetailsByIdQueryResponse(new SuccessfulContentResponse<ProductDetailsDto>(productDetailsDto, ResponseTitles.Success, ResponseMessages.ProductListed, System.Net.HttpStatusCode.OK));
        }
    }
}
