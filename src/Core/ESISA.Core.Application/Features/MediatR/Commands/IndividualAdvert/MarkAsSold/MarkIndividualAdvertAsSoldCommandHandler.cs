using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Mappings.CustomMapper;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.MarkAsSold
{
    public class MarkIndividualAdvertAsSoldCommandHandler : IRequestHandler<MarkIndividualAdvertAsSoldCommandRequest, MarkIndividualAdvertAsSoldCommandResponse>
    {
        private readonly IAdvertQueryRepository _advertQueryRepository;

        private readonly IIndividualAdvertCommandRepository _individualAdvertCommandRepository;
        private readonly IIndividualAdvertQueryRepository _individualAdvertQueryRepository;
        private readonly IndividualAdvertBusinessRules _individualAdvertBusinessRules;

        public MarkIndividualAdvertAsSoldCommandHandler(IAdvertQueryRepository advertQueryRepository, IIndividualAdvertCommandRepository individualAdvertCommandRepository, IIndividualAdvertQueryRepository individualAdvertQueryRepository, IndividualAdvertBusinessRules individualAdvertBusinessRules)
        {
            _advertQueryRepository = advertQueryRepository;

            _individualAdvertCommandRepository = individualAdvertCommandRepository;
            _individualAdvertQueryRepository = individualAdvertQueryRepository;
            _individualAdvertBusinessRules = individualAdvertBusinessRules;
        }

        public async Task<MarkIndividualAdvertAsSoldCommandResponse> Handle(MarkIndividualAdvertAsSoldCommandRequest request, CancellationToken cancellationToken)
        {
            var individualAdvert = await _individualAdvertQueryRepository.GetSingleAsync(e => e.Id == request.IndividualAdvertId);

            await _individualAdvertBusinessRules.NullCheck(individualAdvert);
            await _individualAdvertBusinessRules.CheckIfIndividualAdvertAlreadySold(individualAdvert);

            individualAdvert.IsActive = false;

            _individualAdvertCommandRepository.Update(individualAdvert);
            await _individualAdvertCommandRepository.SaveChangesAsync();

            var advert = await _advertQueryRepository.GetSingleAsync(e => e.Id == individualAdvert.AdvertId);

            var individualAdvertDto = CustomMappingTool.MapToIndividualAdvertDto(advert, individualAdvert);

            return new MarkIndividualAdvertAsSoldCommandResponse(new SuccessfulContentResponse<IndividualAdvertDto>(individualAdvertDto, ResponseTitles.Success, ResponseMessages.AdvertMarkedAsSold, System.Net.HttpStatusCode.OK));
        }
    }
}
