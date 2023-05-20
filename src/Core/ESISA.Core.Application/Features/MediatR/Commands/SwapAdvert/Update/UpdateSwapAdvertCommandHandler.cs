using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.SwapAdvert;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.Update
{
    public class UpdateSwapAdvertCommandHandler : IRequestHandler<UpdateSwapAdvertCommandRequest, UpdateSwapAdvertCommandResponse>
    {
        private readonly IAdvertCommandRepository _advertCommandRepository;
        private readonly IAdvertQueryRepository _advertQueryRepository;

        private readonly ISwapAdvertCommandRepository _swapAdvertCommandRepository;
        private readonly ISwapAdvertQueryRepository _swapAdvertQueryRepository;
        private readonly SwapAdvertBusinessRules _swapAdvertBusinessRules;
        private readonly IMapper _mapper;

        public UpdateSwapAdvertCommandHandler(IAdvertCommandRepository advertCommandRepository, IAdvertQueryRepository advertQueryRepository, ISwapAdvertCommandRepository swapAdvertCommandRepository, ISwapAdvertQueryRepository swapAdvertQueryRepository, SwapAdvertBusinessRules swapAdvertBusinessRules, IMapper mapper)
        {
            _advertCommandRepository = advertCommandRepository;
            _advertQueryRepository = advertQueryRepository;
            _swapAdvertCommandRepository = swapAdvertCommandRepository;
            _swapAdvertQueryRepository = swapAdvertQueryRepository;
            _swapAdvertBusinessRules = swapAdvertBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdateSwapAdvertCommandResponse> Handle(UpdateSwapAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            var advert = await _advertQueryRepository.GetSingleAsync(e => e.Id == request.AdvertId);

            await _swapAdvertBusinessRules.NullCheck(advert);
            _mapper.Map(request, advert);

            _advertCommandRepository.Update(advert);
            await _advertCommandRepository.SaveChangesAsync();

            var swapAdvert = await _swapAdvertQueryRepository.GetSingleAsync(e => e.Id == request.SwapAdvertId);

            await _swapAdvertBusinessRules.NullCheck(swapAdvert);

            _mapper.Map(request, swapAdvert);

            _swapAdvertCommandRepository.Update(swapAdvert);
            await _swapAdvertCommandRepository.SaveChangesAsync();

            var swapAdvertDto = _mapper.Map<SwapAdvertDto>(request);
            this.SetSwapAdvertDto(swapAdvertDto, advert, swapAdvert);

            return new UpdateSwapAdvertCommandResponse(new SuccessfulContentResponse<SwapAdvertDto>(swapAdvertDto, ResponseTitles.Success, ResponseMessages.SwapAdvertUpdate, System.Net.HttpStatusCode.OK));
        }
        private void SetSwapAdvertDto(SwapAdvertDto swapAdvertDto, Advert advert, SwapAdvert swapAdvert)
        {
            swapAdvertDto.AdvertId = advert.Id;
            swapAdvertDto.SwapAdvertId = swapAdvert.Id;

            swapAdvertDto.SwapAdvertIndividualDealerId = swapAdvert.IndividualDealerId;
            swapAdvertDto.SwapAdvertProductId = swapAdvert.ProductId;
        }
    }
}
