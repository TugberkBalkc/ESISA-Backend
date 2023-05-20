using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Update
{
    public class UpdateIndividualAdvertCommandHandler : IRequestHandler<UpdateIndividualAdvertCommandRequest, UpdateIndividualAdvertCommandResponse>
    {
        private readonly IAdvertCommandRepository _advertCommandRepository;
        private readonly IAdvertQueryRepository _advertQueryRepository;

        private readonly IIndividualAdvertCommandRepository _individualAdvertCommandRepository;
        private readonly IIndividualAdvertQueryRepository _individualAdvertQueryRepository;
        private readonly IndividualAdvertBusinessRules _individualAdvertBusinessRules;
        private readonly IMapper _mapper;

        public UpdateIndividualAdvertCommandHandler(IAdvertCommandRepository advertCommandRepository, IAdvertQueryRepository advertQueryRepository, IIndividualAdvertCommandRepository individualAdvertCommandRepository, IIndividualAdvertQueryRepository individualAdvertQueryRepository,IndividualAdvertBusinessRules individualAdvertBusinessRules, IMapper mapper)
        {
            _advertCommandRepository = advertCommandRepository;
            _advertQueryRepository = advertQueryRepository;
            _individualAdvertCommandRepository = individualAdvertCommandRepository;
            _individualAdvertQueryRepository = individualAdvertQueryRepository;
            _individualAdvertBusinessRules = individualAdvertBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdateIndividualAdvertCommandResponse> Handle(UpdateIndividualAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            var advert = await _advertQueryRepository.GetSingleAsync(e => e.Id == request.AdvertId);

            await _individualAdvertBusinessRules.NullCheck(advert);

            _mapper.Map(request, advert);

            _advertCommandRepository.Update(advert);
            await _advertCommandRepository.SaveChangesAsync();

            var individualAdvert = await _individualAdvertQueryRepository.GetSingleAsync(e => e.Id == request.IndividualAdvertId);

            await _individualAdvertBusinessRules.NullCheck(individualAdvert);

            _mapper.Map(request, individualAdvert);

            _individualAdvertCommandRepository.Update(individualAdvert);
            await _individualAdvertCommandRepository.SaveChangesAsync();

            var individualAdvertDto = _mapper.Map<IndividualAdvertDto>(request);
            this.SetIndividualAdvertDto(individualAdvertDto, advert, individualAdvert);

            return new UpdateIndividualAdvertCommandResponse(new SuccessfulContentResponse<IndividualAdvertDto>(individualAdvertDto, ResponseTitles.Success, ResponseMessages.IndividualAdvertUpdated, System.Net.HttpStatusCode.OK));
        }

        private void SetIndividualAdvertDto(IndividualAdvertDto individualAdvertDto, Advert advert, IndividualAdvert individualAdvert)
        {
            individualAdvertDto.AdvertId = advert.Id;
            individualAdvertDto.IndividualAdvertId = individualAdvert.Id;

            individualAdvertDto.IndividualAdvertIndividualDealerId = individualAdvert.IndividualDealerId;
            individualAdvertDto.IndividualAdvertProductId = individualAdvert.ProductId;
        }
    }
}
