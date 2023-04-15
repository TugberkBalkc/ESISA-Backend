using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.CreateIndividualAdvert
{
    public class CreateIndividualAdvertCommandHandler : IRequestHandler<CreateIndividualAdvertCommandRequest, CreateIndividualAdvertCommandResponse>
    {
        private readonly IAdvertCommandRepository _advertCommandRepository;
        private readonly IAdvertQueryRepository _advertQueryRepository;

        private readonly IIndividualAdvertCommandRepository _individualAdvertCommandRepository;
        private readonly IIndividualAdvertQueryRepository _individualAdvertQueryRepository;
        private readonly IndividualAdvertBusinessRules _individualAdvertBusinessRules;

        private readonly IMapper _mapper;

        public CreateIndividualAdvertCommandHandler(IAdvertCommandRepository advertCommandRepository, IAdvertQueryRepository advertQueryRepository, IIndividualAdvertCommandRepository individualAdvertCommandRepository, IIndividualAdvertQueryRepository individualAdvertQueryRepository, IndividualAdvertBusinessRules individualAdvertBusinessRules,IMapper mapper)
        {
            _advertCommandRepository = advertCommandRepository;
            _advertQueryRepository = advertQueryRepository;
            _individualAdvertCommandRepository = individualAdvertCommandRepository;
            _individualAdvertQueryRepository = individualAdvertQueryRepository;
            _individualAdvertBusinessRules = individualAdvertBusinessRules;

            _mapper = mapper;
        }

        public async Task<CreateIndividualAdvertCommandResponse> Handle(CreateIndividualAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            var advertToCheck = await _advertQueryRepository.GetSingleAsync(e => e.Title == request.AdvertTitle && e.Description == request.AdvertDescription);

            await _individualAdvertBusinessRules.ExistsCheck(advertToCheck);

            var advert = _mapper.Map<Advert>(request);

            await _advertCommandRepository.AddAsync(advert);
            await _advertCommandRepository.SaveChangesAsync();

            var individualAdvertToCheck = await _individualAdvertQueryRepository.GetSingleAsync(e => e.AdvertId == advert.Id);

            await _individualAdvertBusinessRules.ExistsCheck(individualAdvertToCheck);

            var individualAdvert = _mapper.Map<IndividualAdvert>(request);
            this.SetIndividualAdvert(individualAdvert, advert.Id);

            await _individualAdvertCommandRepository.AddAsync(individualAdvert);
            await _individualAdvertCommandRepository.SaveChangesAsync();

            var individualAdvertDto = _mapper.Map<IndividualAdvertDto>(request);
            this.SetIndividualAdvertDto(individualAdvertDto, advert, individualAdvert.Id);

            return new CreateIndividualAdvertCommandResponse(new SuccessfulContentResponse<IndividualAdvertDto>(individualAdvertDto, ResponseTitles.Success, ResponseMessages.IndividualAdvertCreated, System.Net.HttpStatusCode.Created));
        }

        private void SetIndividualAdvert(IndividualAdvert individualAdvert, Guid advertId)
        {
            individualAdvert.AdvertId = advertId;
        }

        private void SetIndividualAdvertDto(IndividualAdvertDto individualAdvertDto, Advert advert, Guid individualAdvertId)
        {
            individualAdvertDto.AdvertId = advert.Id;
            individualAdvertDto.IndividualAdvertId = individualAdvertId;

            individualAdvertDto.AdvertCreatedDate = advert.CreatedDate;
            individualAdvertDto.AdvertModifiedDate = advert.ModifiedDate;
            individualAdvertDto.AdvertIsActive = advert.IsActive;
            individualAdvertDto.AdvertIsDeleted = advert.IsDeleted;

        }
    }
}
