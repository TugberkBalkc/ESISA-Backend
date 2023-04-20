using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.DeletePhoto
{
    public class DeletePhotoInIndividualAdvertCommandHandler : IRequestHandler<DeletePhotoInIndividualAdvertCommandRequest, DeletePhotoInIndividualAdvertCommandResponse>
    {
        private readonly IAdvertQueryRepository _advertQueryRepository;

        private readonly IIndividualAdvertQueryRepository _individualAdvertQueryRepository;
        private readonly IndividualAdvertBusinessRules _individualAdvertBusinessRules;

        private readonly IAdvertPhotoPathCommandRepository _photoPathCommandRepository;
        private readonly IAdvertPhotoPathQueryRepository _photoPathQueryRepository;
        private readonly PhotoPathBusinessRules _photoPathBusinessRules;
        public DeletePhotoInIndividualAdvertCommandHandler(IAdvertQueryRepository advertQueryRepository, IIndividualAdvertQueryRepository individualAdvertQueryRepository, IndividualAdvertBusinessRules individualAdvertBusinessRules, IAdvertPhotoPathCommandRepository photoPathCommandRepository, IAdvertPhotoPathQueryRepository photoPathQueryRepository, PhotoPathBusinessRules photoPathBusinessRules)
        {
            _advertQueryRepository = advertQueryRepository;

            _individualAdvertQueryRepository = individualAdvertQueryRepository;
            _individualAdvertBusinessRules = individualAdvertBusinessRules;

            _photoPathCommandRepository = photoPathCommandRepository;
            _photoPathQueryRepository = photoPathQueryRepository;
            _photoPathBusinessRules = photoPathBusinessRules;
        }

        public async Task<DeletePhotoInIndividualAdvertCommandResponse> Handle(DeletePhotoInIndividualAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            var individualAdvertToCheck = await _individualAdvertQueryRepository.GetSingleAsync(e => e.Id == request.IndividualAdvertId);

            await _individualAdvertBusinessRules.NullCheck(individualAdvertToCheck);
            await _individualAdvertBusinessRules.CheckIfIndividualAdvertSold(individualAdvertToCheck);

            var advertPhotoPath = await _photoPathQueryRepository.GetSingleAsync(e => e.PhotoPath == request.PhotoUrl);

            await _photoPathBusinessRules.NullCheck(advertPhotoPath);

            _photoPathCommandRepository.Delete(advertPhotoPath);
            await _photoPathCommandRepository.SaveChangesAsync();

            return new DeletePhotoInIndividualAdvertCommandResponse(new SuccessfulContentResponse<Guid>(advertPhotoPath.Id, ResponseTitles.Success, ResponseMessages.PhotoDeletedInAdvert, System.Net.HttpStatusCode.OK));
        }
    }
}
