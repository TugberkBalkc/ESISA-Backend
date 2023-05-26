using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.WholesaleAdverts.Delete
{
    public class DeleteWholesaleAdvertCommandHandler : IRequestHandler<DeleteWholesaleAdvertCommandRequest, DeleteWholesaleAdvertCommandResponse>
    {
        private readonly IAdvertCommandRepository _advertCommandRepository;
        private readonly IAdvertQueryRepository _advertQueryRepository;

        private readonly IWholesaleAdvertCommandRepository _wholesaleAdvertCommandRepository;
        private readonly IWholesaleAdvertQueryRepository _wholesaleAdvertQueryRepository;
        private readonly WholesaleAdvertBusinessRules _wholesaleAdvertBusinessRules;

        public DeleteWholesaleAdvertCommandHandler(IAdvertCommandRepository advertCommandRepository, IAdvertQueryRepository advertQueryRepository, IWholesaleAdvertCommandRepository wholesaleAdvertCommandRepository, IWholesaleAdvertQueryRepository wholesaleAdvertQueryRepository, WholesaleAdvertBusinessRules wholesaleAdvertBusinessRules)
        {
            _advertCommandRepository = advertCommandRepository;
            _advertQueryRepository = advertQueryRepository;
            _wholesaleAdvertCommandRepository = wholesaleAdvertCommandRepository;
            _wholesaleAdvertQueryRepository = wholesaleAdvertQueryRepository;
            _wholesaleAdvertBusinessRules = wholesaleAdvertBusinessRules;
        }

        public async Task<DeleteWholesaleAdvertCommandResponse> Handle(DeleteWholesaleAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            var wholesaleAdvert = await _wholesaleAdvertQueryRepository.GetSingleAsync(e => e.Id == request.WholesaleAdvertId);

            await _wholesaleAdvertBusinessRules.NullCheck(wholesaleAdvert);

            var advert = await _advertQueryRepository.GetSingleAsync(e => e.Id == wholesaleAdvert.AdvertId);

            await _wholesaleAdvertBusinessRules.NullCheck(advert);

            _wholesaleAdvertCommandRepository.Delete(wholesaleAdvert);
            await _wholesaleAdvertCommandRepository.SaveChangesAsync();

            _advertCommandRepository.Delete(advert);
            await _advertCommandRepository.SaveChangesAsync();

            return new DeleteWholesaleAdvertCommandResponse(new SuccessfulContentResponse<Guid>(wholesaleAdvert.Id, ResponseTitles.Success, ResponseMessages.WholesaleAdvertDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
