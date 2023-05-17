using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.SwapAdvert;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;
using System.Net;

namespace ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.AddSwappableProduct
{
    public class AddSwappableProductCommandHandler :
        IRequestHandler<AddSwappableProductCommandRequest, AddSwappableProductCommandResponse>
    {
        private readonly ISwapAdvertSwapableProductCommandRepository _swapAdvertSwapableProductCommandRepository;
        private readonly ISwapAdvertSwapableProductQueryRepository _swapAdvertSwapableProductQueryRepository;
        private readonly ISwapAdvertQueryRepository _swapAdvertQueryRepository;
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly SwapAdvertBusinessRules _swapAdvertBusinessRules;
        private readonly IMapper _mapper;

        public AddSwappableProductCommandHandler(ISwapAdvertSwapableProductCommandRepository swapAdvertSwapableProductCommandRepository, ISwapAdvertSwapableProductQueryRepository swapAdvertSwapableProductQueryRepository, SwapAdvertBusinessRules swapAdvertBusinessRules, IMapper mapper, ISwapAdvertQueryRepository swapAdvertQueryRepository, IProductQueryRepository productQueryRepository, ProductBusinessRules productBusinessRules)
        {
            _swapAdvertSwapableProductCommandRepository = swapAdvertSwapableProductCommandRepository;
            _swapAdvertSwapableProductQueryRepository = swapAdvertSwapableProductQueryRepository;
            _swapAdvertBusinessRules = swapAdvertBusinessRules;
            _mapper = mapper;
            _swapAdvertQueryRepository = swapAdvertQueryRepository;
            _productQueryRepository = productQueryRepository;
            _productBusinessRules = productBusinessRules;
        }

        public async Task<AddSwappableProductCommandResponse> Handle(AddSwappableProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productQueryRepository.GetByIdAsync(request.ProductId);

            await _productBusinessRules.NullCheck(product);

            var swapAdvert = await _swapAdvertQueryRepository.GetByIdAsync(request.SwapAdvertId);

            await _swapAdvertBusinessRules.NullCheck(swapAdvert);

            var swapAdvertSwappableProductToCheck = await _swapAdvertSwapableProductQueryRepository.GetSingleAsync(e => e.ProductId == request.ProductId && e.SwapAdvertId == request.SwapAdvertId);

            await _swapAdvertBusinessRules.ExistsCheck(swapAdvertSwappableProductToCheck);
            await _swapAdvertBusinessRules.CheckIfSwapAdvertActive(swapAdvert);

            var swapAdvertSwappableProduct = _mapper.Map<SwapAdvertSwapableProduct>(request);

            await _swapAdvertSwapableProductCommandRepository.AddAsync(swapAdvertSwappableProduct);
            await _swapAdvertSwapableProductCommandRepository.SaveChangesAsync();

            var swapAdvertSwappableProductDto = _mapper.Map<SwapAdvertSwappableProductDto>(swapAdvertSwappableProduct);

            return new AddSwappableProductCommandResponse(new SuccessfulContentResponse<SwapAdvertSwappableProductDto>(swapAdvertSwappableProductDto, ResponseTitles.Success, ResponseMessages.ProductAddedToSwappableList, HttpStatusCode.Created));
        }
    }
}
