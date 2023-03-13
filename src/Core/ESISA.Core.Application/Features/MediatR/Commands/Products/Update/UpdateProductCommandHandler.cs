using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Product;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Products.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler
            (IProductCommandRepository productCommandRepository, IProductQueryRepository productQueryRepository,
             ProductBusinessRules productBusinessRules, IMapper mapper)
        {
            _productCommandRepository = productCommandRepository;
            _productQueryRepository = productQueryRepository;
            _productBusinessRules = productBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productQueryRepository.GetByIdAsync(request.ProductId);

            await _productBusinessRules.NullCheck(product);

            _mapper.Map(request, product);

            _productCommandRepository.Update(product);

            await _productCommandRepository.SaveChangesAsync();

            var productDto = _mapper.Map<ProductDto>(product);

            return new UpdateProductCommandResponse(new SuccessfulContentResponse<ProductDto>(productDto, ResponseTitles.Success, ResponseMessages.ProductUpdated, System.Net.HttpStatusCode.OK));
        }
    }
}
