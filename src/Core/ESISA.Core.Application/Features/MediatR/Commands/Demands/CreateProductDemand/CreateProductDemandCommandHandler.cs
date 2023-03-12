using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Extensions;
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
        private readonly IProductDemandQueryRepository _productDemandQueryRepository;
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly ProductDemandBusinessRules _productDemandBusinessRules;
        private readonly IMapper _mapper;

        public CreateProductDemandCommandHandler
            (IProductDemandCommandRepository productDemandCommandRepository, IProductDemandQueryRepository productDemandQueryRepository, IProductQueryRepository productQueryRepository, ProductDemandBusinessRules productDemandBusinessRules, 
             IMapper mapper)
        {
            _productDemandCommandRepository = productDemandCommandRepository;
            _productDemandQueryRepository = productDemandQueryRepository;
            _productQueryRepository = productQueryRepository;
            _productDemandBusinessRules = productDemandBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreateProductDemandCommandResponse> Handle(CreateProductDemandCommandRequest request, CancellationToken cancellationToken)
        {
            var productToCheck = await _productQueryRepository.GetSingleAsync(e=>e.Name == request.ProductName);

            await _productDemandBusinessRules.ExistsCheck(productToCheck);

            var productDemandToCheck = await _productDemandQueryRepository.GetSingleAsync(e => e.ProductName.GetTrimmedLowered() == request.ProductName.GetTrimmedLowered());

            await _productDemandBusinessRules.ExistsCheck(productDemandToCheck);

            var productDemand = _mapper.Map<ProductDemand>(request);

            await _productDemandCommandRepository.AddAsync(productDemand);

            await _productDemandCommandRepository.SaveChangesAsync();

            var productDemandDto = _mapper.Map<ProductDemandDto>(productDemand);

            return new CreateProductDemandCommandResponse(new SuccessfulContentResponse<ProductDemandDto>(productDemandDto, ResponseTitles.Success, ResponseMessages.DemandSent, System.Net.HttpStatusCode.OK));
        }
    }
}
