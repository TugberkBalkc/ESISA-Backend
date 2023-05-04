using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.DeletePhoto
{
    public class DeletePhotoInCorporateAdvertCommandHandler : IRequestHandler<DeletePhotoInCorporateAdvertCommandRequest, DeletePhotoInCorporateAdvertCommandResponse>
    {
        private readonly IAdvertQueryRepository _advertQueryRepository;

        private readonly ICorporateAdvertQueryRepository _corporateAdvertQueryRepository;
        private readonly CorporateAdvertBusinessRules _corporateAdvertBusinessRules;

        private readonly IAdvertPhotoPathCommandRepository _photoPathCommandRepository;
        private readonly IAdvertPhotoPathQueryRepository _photoPathQueryRepository;
        private readonly PhotoPathBusinessRules _photoPathBusinessRules;
        public DeletePhotoInCorporateAdvertCommandHandler(IAdvertQueryRepository advertQueryRepository, ICorporateAdvertQueryRepository corporateAdvertQueryRepository, CorporateAdvertBusinessRules corporateAdvertBusinessRules, IAdvertPhotoPathCommandRepository photoPathCommandRepository, IAdvertPhotoPathQueryRepository photoPathQueryRepository, PhotoPathBusinessRules photoPathBusinessRules)
        {
            _advertQueryRepository = advertQueryRepository;

            _corporateAdvertQueryRepository = corporateAdvertQueryRepository;
            _corporateAdvertBusinessRules = corporateAdvertBusinessRules;

            _photoPathCommandRepository = photoPathCommandRepository;
            _photoPathQueryRepository = photoPathQueryRepository;
            _photoPathBusinessRules = photoPathBusinessRules;
        }

        public async Task<DeletePhotoInCorporateAdvertCommandResponse> Handle(DeletePhotoInCorporateAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            var corporateAdvertToCheck = await _corporateAdvertQueryRepository.GetSingleAsync(e => e.Id == request.CorporateAdvertId);

            await _corporateAdvertBusinessRules.NullCheck(corporateAdvertToCheck);
            await _corporateAdvertBusinessRules.CheckIfCorporateAdvertSold(corporateAdvertToCheck);

            var advertPhotoPath = await _photoPathQueryRepository.GetSingleAsync(e => e.PhotoPath == request.PhotoUrl);

            await _photoPathBusinessRules.NullCheck(advertPhotoPath);

            _photoPathCommandRepository.Delete(advertPhotoPath);
            await _photoPathCommandRepository.SaveChangesAsync();

            return new DeletePhotoInCorporateAdvertCommandResponse(new SuccessfulContentResponse<Guid>(advertPhotoPath.Id, ResponseTitles.Success, ResponseMessages.PhotoDeletedInAdvert, System.Net.HttpStatusCode.OK));
        }
    }
}
