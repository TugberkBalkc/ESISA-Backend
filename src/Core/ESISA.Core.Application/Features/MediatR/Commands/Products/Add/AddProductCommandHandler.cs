using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos;
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

namespace ESISA.Core.Application.Features.MediatR.Commands.Products.Add
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
    {
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly IMapper _mapper;

        public AddProductCommandHandler
            (IProductCommandRepository productCommandRepository, ProductBusinessRules productBusinessRules, 
             IMapper mapper)
        {
            _productCommandRepository = productCommandRepository;
            _productBusinessRules = productBusinessRules;
            _mapper = mapper;
        }

        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productBusinessRules.ExistsCheckByProductName(request.ProductName);

            var product = _mapper.Map<Product>(request);

            await _productCommandRepository.AddAsync(product);

            await _productCommandRepository.SaveChangesAsync();

            var productDto = _mapper.Map<ProductDto>(product);

            return new AddProductCommandResponse(new SuccessfulContentResponse<ProductDto>(productDto, ResponseTitles.Success, ResponseMessages.ProductAdded, System.Net.HttpStatusCode.OK));
        }
    }
}
