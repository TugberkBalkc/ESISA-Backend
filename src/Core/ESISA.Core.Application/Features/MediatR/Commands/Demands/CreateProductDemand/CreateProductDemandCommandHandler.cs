using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.CreateProductDemand
{
    public class CreateProductDemandCommandHandler : IRequestHandler<CreateProductDemandCommandRequest, CreateProductDemandCommandResponse>
    {
        private readonly IProductDemandCommandRepository _productDemandCommandRepository;
        private readonly ProductDemandBusinessRules _productDemandBusinessRules;
        private readonly IMapper _mapper;

        public CreateProductDemandCommandHandler
            (IProductDemandCommandRepository productDemandCommandRepository, ProductDemandBusinessRules productDemandBusinessRules, 
             IMapper mapper)
        {
            _productDemandCommandRepository = productDemandCommandRepository;
            _productDemandBusinessRules = productDemandBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreateProductDemandCommandResponse> Handle(CreateProductDemandCommandRequest request, CancellationToken cancellationToken)
        {
            await _productDemandBusinessRules.CheckIfDemandedProductExistsByProductName(request.ProductName);   

            await _productDemandBusinessRules.CheckIfProductDemandExists(request.ProductName);

            var productDemand = _mapper.Map<ProductDemand>(request);

            await _productDemandCommandRepository.AddAsync(productDemand);

            await _productDemandCommandRepository.SaveChangesAsync();

            var productDemandDto = _mapper.Map<ProductDemandDto>(productDemand);

            return new CreateProductDemandCommandResponse(new SuccessfulContentResponse<ProductDemandDto>(productDemandDto, ResponseTitles.Success, ResponseMessages.DemandSent, System.Net.HttpStatusCode.OK));
        }
    }
}
