using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.Delete
{
    public class DeleteSwapAdvertCommandHandler : IRequestHandler<DeleteSwapAdvertCommandRequest, DeleteSwapAdvertCommandResponse>
    {
        private readonly IAdvertCommandRepository _advertCommandRepository;
        private readonly IAdvertQueryRepository _advertQueryRepository;

        private readonly ISwapAdvertCommandRepository _swapAdvertCommandRepository;
        private readonly ISwapAdvertQueryRepository _swapAdvertQueryRepository;
        private readonly SwapAdvertBusinessRules _swapAdvertBusinessRules;

        public DeleteSwapAdvertCommandHandler(IAdvertCommandRepository advertCommandRepository, IAdvertQueryRepository advertQueryRepository, ISwapAdvertCommandRepository swapAdvertCommandRepository, ISwapAdvertQueryRepository swapAdvertQueryRepository, SwapAdvertBusinessRules swapAdvertBusinessRules)
        {
            _advertCommandRepository = advertCommandRepository;
            _advertQueryRepository = advertQueryRepository;
            _swapAdvertCommandRepository = swapAdvertCommandRepository;
            _swapAdvertQueryRepository = swapAdvertQueryRepository;
            _swapAdvertBusinessRules = swapAdvertBusinessRules;
        }

        public async Task<DeleteSwapAdvertCommandResponse> Handle(DeleteSwapAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            var swapAdvert = await _swapAdvertQueryRepository.GetSingleAsync(e => e.Id == request.SwapAdvertId);

            await _swapAdvertBusinessRules.NullCheck(swapAdvert);

            var advert = await _advertQueryRepository.GetSingleAsync(e => e.Id == swapAdvert.AdvertId);

            await _swapAdvertBusinessRules.NullCheck(advert);

            _swapAdvertCommandRepository.Delete(swapAdvert);
            await _swapAdvertCommandRepository.SaveChangesAsync();

            _advertCommandRepository.Delete(advert);
            await _advertCommandRepository.SaveChangesAsync();

            return new DeleteSwapAdvertCommandResponse(new SuccessfulContentResponse<Guid>(swapAdvert.Id, ResponseTitles.Success, ResponseMessages.SwapAdvertDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
