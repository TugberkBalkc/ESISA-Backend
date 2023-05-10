using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.Common;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.AddPhoto
{
    public class AddPhotoToSwapAdvertCommandHandler : IRequestHandler<AddPhotoToSwapAdvertCommandRequest, AddPhotoToSwapAdvertCommandResponse>
    {
        private readonly ISwapAdvertQueryRepository _swapAdvertQueryRepository;
        private readonly SwapAdvertBusinessRules _swapAdvertBusinessRules;

        private readonly IAdvertPhotoPathCommandRepository _photoPathCommandRepository;
        private readonly IAdvertPhotoPathQueryRepository _photoPathQueryRepository;
        private readonly PhotoPathBusinessRules _photoPathBusinessRules;

        private readonly IMapper _mapper;
        public AddPhotoToSwapAdvertCommandHandler(ISwapAdvertQueryRepository swapAdvertQueryRepository, SwapAdvertBusinessRules swapAdvertBusinessRules, IAdvertPhotoPathCommandRepository photoPathCommandRepository, IAdvertPhotoPathQueryRepository photoPathQueryRepository, PhotoPathBusinessRules photoPathBusinessRules,
          IMapper mapper)
        {
            _swapAdvertQueryRepository = swapAdvertQueryRepository;
            _swapAdvertBusinessRules = swapAdvertBusinessRules;

            _photoPathCommandRepository = photoPathCommandRepository;
            _photoPathQueryRepository = photoPathQueryRepository;
            _photoPathBusinessRules = photoPathBusinessRules;

            _mapper = mapper;
        }

        public async Task<AddPhotoToSwapAdvertCommandResponse> Handle(AddPhotoToSwapAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            var swapAdvertToCheck = await _swapAdvertQueryRepository.GetSingleAsync(e => e.Id == request.SwapAdvertId);

            await _swapAdvertBusinessRules.NullCheck(swapAdvertToCheck);
            await _swapAdvertBusinessRules.CheckIfSwapAdvertActive(swapAdvertToCheck);

            var advertPhotoPathToCheck = await _photoPathQueryRepository.GetSingleAsync(e => e.PhotoPath == request.PhotoUrl && e.AdvertId == swapAdvertToCheck.AdvertId);

            await _photoPathBusinessRules.ExistsCheck(advertPhotoPathToCheck);

            var advertPhotoPath = new AdvertPhotoPath() { AdvertId = swapAdvertToCheck.AdvertId, PhotoPath = request.PhotoUrl };

            await _photoPathCommandRepository.AddAsync(advertPhotoPath);
            await _photoPathCommandRepository.SaveChangesAsync();

            var advertPhotoPathDto = _mapper.Map<AdvertPhotoPathDto>(advertPhotoPath);

            return new AddPhotoToSwapAdvertCommandResponse(new SuccessfulContentResponse<AdvertPhotoPathDto>(advertPhotoPathDto, ResponseTitles.Success, ResponseMessages.PhotoAddedToAdvert, System.Net.HttpStatusCode.OK));
        }
    }
}
