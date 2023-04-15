using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Delete
{
    public class DeleteIndividualAdvertCommandHandler : IRequestHandler<DeleteIndividualAdvertCommandRequest, DeleteIndividualAdvertCommandResponse>
    {
        private readonly IAdvertCommandRepository _advertCommandRepository;
        private readonly IAdvertQueryRepository _advertQueryRepository;

        private readonly IIndividualAdvertCommandRepository _individualAdvertCommandRepository;
        private readonly IIndividualAdvertQueryRepository _individualAdvertQueryRepository;
        private readonly IndividualAdvertBusinessRules _individualAdvertBusinessRules;

        public DeleteIndividualAdvertCommandHandler(IAdvertCommandRepository advertCommandRepository, IAdvertQueryRepository advertQueryRepository, IIndividualAdvertCommandRepository individualAdvertCommandRepository, IIndividualAdvertQueryRepository individualAdvertQueryRepository, IndividualAdvertBusinessRules individualAdvertBusinessRules)
        {
            _advertCommandRepository = advertCommandRepository;
            _advertQueryRepository = advertQueryRepository;
            _individualAdvertCommandRepository = individualAdvertCommandRepository;
            _individualAdvertQueryRepository = individualAdvertQueryRepository;
            _individualAdvertBusinessRules = individualAdvertBusinessRules;
        }

        public async Task<DeleteIndividualAdvertCommandResponse> Handle(DeleteIndividualAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            var individualAdvert = await _individualAdvertQueryRepository.GetSingleAsync(e => e.Id == request.IndividualAdvertId);

            await _individualAdvertBusinessRules.NullCheck(individualAdvert);

            var advert = await _advertQueryRepository.GetSingleAsync(e => e.Id == individualAdvert.AdvertId);

            await _individualAdvertBusinessRules.NullCheck(advert);

            _individualAdvertCommandRepository.Delete(individualAdvert);
            await _individualAdvertCommandRepository.SaveChangesAsync();

            _advertCommandRepository.Delete(advert);
            await _advertCommandRepository.SaveChangesAsync();
            
            return new DeleteIndividualAdvertCommandResponse(new SuccessfulContentResponse<Guid>(individualAdvert.Id, ResponseTitles.Success, ResponseMessages.InidividualAdvertDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
