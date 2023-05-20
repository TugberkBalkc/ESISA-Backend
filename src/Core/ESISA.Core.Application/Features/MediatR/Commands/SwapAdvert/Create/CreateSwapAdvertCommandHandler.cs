using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.SwapAdvert;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.Create
{
    public class CreateSwapAdvertCommandHandler : IRequestHandler<CreateSwapAdvertCommandRequest, CreateSwapAdvertCommandResponse>
    {
        private readonly IAdvertCommandRepository _advertCommandRepository;
        private readonly IAdvertQueryRepository _advertQueryRepository;

        private readonly ISwapAdvertCommandRepository _swapAdvertCommandRepository;
        private readonly ISwapAdvertQueryRepository _swapAdvertQueryRepository;
        private readonly SwapAdvertBusinessRules _swapAdvertBusinessRules;

        private readonly IMapper _mapper;

        public CreateSwapAdvertCommandHandler(IAdvertCommandRepository advertCommandRepository, IAdvertQueryRepository advertQueryRepository, ISwapAdvertCommandRepository swapAdvertCommandRepository, ISwapAdvertQueryRepository swapAdvertQueryRepository, SwapAdvertBusinessRules swapAdvertBusinessRules, IMapper mapper)
        {
            _advertCommandRepository = advertCommandRepository;
            _advertQueryRepository = advertQueryRepository;
            _swapAdvertCommandRepository = swapAdvertCommandRepository;
            _swapAdvertQueryRepository = swapAdvertQueryRepository;
            _swapAdvertBusinessRules = swapAdvertBusinessRules;

            _mapper = mapper;
        }


        public async Task<CreateSwapAdvertCommandResponse> Handle(CreateSwapAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            var advertToCheck = await _advertQueryRepository.GetSingleAsync(e => e.Title == request.AdvertTitle && e.Description == request.AdvertDescription);

            await _swapAdvertBusinessRules.ExistsCheck(advertToCheck);

            var advert = _mapper.Map<Advert>(request);

            await _advertCommandRepository.AddAsync(advert);
            await _advertCommandRepository.SaveChangesAsync();

            var swapAdvertToCheck = await _swapAdvertQueryRepository.GetSingleAsync(e => e.AdvertId == advert.Id);

            await _swapAdvertBusinessRules.ExistsCheck(swapAdvertToCheck);

            var swapAdvert = _mapper.Map<SwapAdvert>(request);
            this.SetSwapAdvert(swapAdvert, advert.Id);

            await _swapAdvertCommandRepository.AddAsync(swapAdvert);
            await _swapAdvertCommandRepository.SaveChangesAsync();

            var swapAdvertDto = _mapper.Map<SwapAdvertDto>(request);
            this.SetSwapAdvertDto(swapAdvertDto, advert, swapAdvert.Id);

            return new CreateSwapAdvertCommandResponse(new SuccessfulContentResponse<SwapAdvertDto>(swapAdvertDto, ResponseTitles.Success, ResponseMessages.SwapAdvertCreated, System.Net.HttpStatusCode.Created));
        }

        private void SetSwapAdvert(SwapAdvert swapAdvert, Guid advertId)
        {
            swapAdvert.AdvertId = advertId;
        }

        private void SetSwapAdvertDto(SwapAdvertDto swapAdvertDto, Advert advert, Guid swapAdvertId)
        {
            swapAdvertDto.AdvertId = advert.Id;
            swapAdvertDto.SwapAdvertId = swapAdvertId;
            swapAdvertDto.IsSwapAdvertActive = advert.IsActive;
        }
    }
}
