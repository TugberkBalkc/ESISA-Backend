using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.CorporateAdverts;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.Create
{
    public class CreateCorporateAdvertCommandHandler : IRequestHandler<CreateCorporateAdvertCommandRequest, CreateCorporateAdvertCommandResponse>
    {
        private readonly IAdvertCommandRepository _advertCommandRepository;
        private readonly IAdvertQueryRepository _advertQueryRepository;
        private readonly ICorporateAdvertCommandRepository _corporateAdvertCommandRepository;
        private readonly ICorporateAdvertQueryRepository _corporateAdvertQueryRepository;
        private readonly CorporateAdvertBusinessRules _corporateAdvertBusinessRules;
        private readonly IMapper _mapper;

        public CreateCorporateAdvertCommandHandler(IAdvertCommandRepository advertCommandRepository, IAdvertQueryRepository advertQueryRepository, ICorporateAdvertCommandRepository corporateAdvertCommandRepository, ICorporateAdvertQueryRepository corporateAdvertQueryRepository, CorporateAdvertBusinessRules corporateAdvertBusinessRules, IMapper mapper)
        {
            _advertCommandRepository = advertCommandRepository;
            _advertQueryRepository = advertQueryRepository;
            _corporateAdvertCommandRepository = corporateAdvertCommandRepository;
            _corporateAdvertQueryRepository = corporateAdvertQueryRepository;
            _corporateAdvertBusinessRules = corporateAdvertBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreateCorporateAdvertCommandResponse> Handle(CreateCorporateAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            //TODO Add DealerId Restriction To Extend Logic!!!
            var advertToCheck = await _advertQueryRepository.GetSingleAsync(e => e.Title == request.AdvertTitle && e.Description == request.AdvertDescription);

            await _corporateAdvertBusinessRules.ExistsCheck(advertToCheck);
            var advert = _mapper.Map<Advert>(request);

            await _advertCommandRepository.AddAsync(advert);
            await _advertCommandRepository.SaveChangesAsync();

            var corporateAdvertToCheck = await _corporateAdvertQueryRepository.GetSingleAsync(e => e.AdvertId == advert.Id);

            await _corporateAdvertBusinessRules.ExistsCheck(corporateAdvertToCheck);

            var corporateAdvert = _mapper.Map<CorporateAdvert>(request);
            this.SetCorporateAdvert(corporateAdvert, advert.Id);

            await _corporateAdvertCommandRepository.AddAsync(corporateAdvert);
            await _corporateAdvertCommandRepository.SaveChangesAsync();

            var corporateAdvertDto = _mapper.Map<CorporateAdvertDto>(request);
            this.SetCorporateAdvertDto(corporateAdvertDto, advert, corporateAdvert.Id);

            return new CreateCorporateAdvertCommandResponse(new SuccessfulContentResponse<CorporateAdvertDto>(corporateAdvertDto, ResponseTitles.Success, ResponseMessages.CorporateAdvertCreated, System.Net.HttpStatusCode.Created));
        }

        private void SetCorporateAdvert(CorporateAdvert corporateAdvert, Guid advertId)
        {
            corporateAdvert.AdvertId = advertId;
        }

        private void SetCorporateAdvertDto(CorporateAdvertDto corporateAdvertDto, Advert advert, Guid corporateAdvertId)
        {
            corporateAdvertDto.AdvertId = advert.Id;
            corporateAdvertDto.CorporateAdvertId = corporateAdvertId;
            corporateAdvertDto.IsCorporateAdvertActive = advert.IsActive;
        }
    }
}
