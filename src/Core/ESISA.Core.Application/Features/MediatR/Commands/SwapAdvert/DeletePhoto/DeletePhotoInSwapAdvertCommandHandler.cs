using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.DeletePhoto
{
    public class DeletePhotoInSwapAdvertCommandHandler : IRequestHandler<DeletePhotoInSwapAdvertCommandRequest, DeletePhotoInSwapAdvertCommandResponse>
    {
        private readonly IAdvertQueryRepository _advertQueryRepository;

        private readonly ISwapAdvertQueryRepository _swapAdvertQueryRepository;
        private readonly SwapAdvertBusinessRules _swapAdvertBusinessRules;

        private readonly IAdvertPhotoPathCommandRepository _photoPathCommandRepository;
        private readonly IAdvertPhotoPathQueryRepository _photoPathQueryRepository;
        private readonly PhotoPathBusinessRules _photoPathBusinessRules;
        public DeletePhotoInSwapAdvertCommandHandler(IAdvertQueryRepository advertQueryRepository, ISwapAdvertQueryRepository swapAdvertQueryRepository, SwapAdvertBusinessRules swapAdvertBusinessRules, IAdvertPhotoPathCommandRepository photoPathCommandRepository, IAdvertPhotoPathQueryRepository photoPathQueryRepository, PhotoPathBusinessRules photoPathBusinessRules)
        {
            _advertQueryRepository = advertQueryRepository;

            _swapAdvertQueryRepository = swapAdvertQueryRepository;
            _swapAdvertBusinessRules = swapAdvertBusinessRules;

            _photoPathCommandRepository = photoPathCommandRepository;
            _photoPathQueryRepository = photoPathQueryRepository;
            _photoPathBusinessRules = photoPathBusinessRules;
        }

        public async Task<DeletePhotoInSwapAdvertCommandResponse> Handle(DeletePhotoInSwapAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            var swapAdvertToCheck = await _swapAdvertQueryRepository.GetSingleAsync(e => e.Id == request.SwapAdvertId);

            await _swapAdvertBusinessRules.NullCheck(swapAdvertToCheck);
            await _swapAdvertBusinessRules.CheckIfSwapAdvertActive(swapAdvertToCheck);

            var advertPhotoPath = await _photoPathQueryRepository.GetSingleAsync(e => e.PhotoPath == request.PhotoUrl);

            await _photoPathBusinessRules.NullCheck(advertPhotoPath);

            _photoPathCommandRepository.Delete(advertPhotoPath);
            await _photoPathCommandRepository.SaveChangesAsync();

            return new DeletePhotoInSwapAdvertCommandResponse(new SuccessfulContentResponse<Guid>(advertPhotoPath.Id, ResponseTitles.Success, ResponseMessages.PhotoDeletedInAdvert, System.Net.HttpStatusCode.OK));
        }
    }
}
