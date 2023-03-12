using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Extensions.String;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Products.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler
            (IProductCommandRepository productCommandRepository, IProductQueryRepository productQueryRepository, ProductBusinessRules productBusinessRules, 
             IMapper mapper)
        {
            _productCommandRepository = productCommandRepository;
            _productQueryRepository = productQueryRepository;
            _productBusinessRules = productBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var productToCheck = await _productQueryRepository.GetSingleAsync(e => e.Name.GetTrimmedLowered() == request.ProductName.GetTrimmedLowered());

            await _productBusinessRules.ExistsCheck(productToCheck);

            var product = _mapper.Map<Product>(request);

            await _productCommandRepository.AddAsync(product);

            await _productCommandRepository.SaveChangesAsync();

            var productDto = _mapper.Map<ProductDto>(product);

            return new CreateProductCommandResponse(new SuccessfulContentResponse<ProductDto>(productDto, ResponseTitles.Success, ResponseMessages.ProductCreated, System.Net.HttpStatusCode.OK));
        }
    }
}
