using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.CorporateAdverts;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.Update
{
    public class UpdateCorporateAdvertCommandHandler : IRequestHandler<UpdateCorporateAdvertCommandRequest, UpdateCorporateAdvertCommandResponse>
    {
        private readonly IAdvertCommandRepository _advertCommandRepository;
        private readonly IAdvertQueryRepository _advertQueryRepository;
        private readonly ICorporateAdvertCommandRepository _corporateAdvertCommandRepository;
        private readonly ICorporateAdvertQueryRepository _corporateAdvertQueryRepository;
        private readonly CorporateAdvertBusinessRules _corporateAdvertBusinessRules;
        private readonly IMapper _mapper;

        public UpdateCorporateAdvertCommandHandler(IAdvertCommandRepository advertCommandRepository, IAdvertQueryRepository advertQueryRepository, ICorporateAdvertCommandRepository corporateAdvertCommandRepository, ICorporateAdvertQueryRepository corporateAdvertQueryRepository, CorporateAdvertBusinessRules corporateAdvertBusinessRules, IMapper mapper)
        {
            _advertCommandRepository = advertCommandRepository;
            _advertQueryRepository = advertQueryRepository;
            _corporateAdvertCommandRepository = corporateAdvertCommandRepository;
            _corporateAdvertQueryRepository = corporateAdvertQueryRepository;
            _corporateAdvertBusinessRules = corporateAdvertBusinessRules;
            _mapper = mapper;
        }

        public async Task<UpdateCorporateAdvertCommandResponse> Handle(UpdateCorporateAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            var advert = await _advertQueryRepository.GetSingleAsync(e => e.Id == request.AdvertId);

            await _corporateAdvertBusinessRules.NullCheck(advert);

            _mapper.Map(request, advert);

            _advertCommandRepository.Update(advert);
            await _advertCommandRepository.SaveChangesAsync();

            var corporateAdvert = await _corporateAdvertQueryRepository.GetSingleAsync(e => e.Id == request.CorporateAdvertId);

            await _corporateAdvertBusinessRules.NullCheck(corporateAdvert);

            _mapper.Map(request, corporateAdvert);

            _corporateAdvertCommandRepository.Update(corporateAdvert);
            await _corporateAdvertCommandRepository.SaveChangesAsync();

            var corporateAdvertDto = _mapper.Map<CorporateAdvertDto>(request);
            this.SetCorporateAdvertDto(corporateAdvertDto, advert, corporateAdvert);

            return new UpdateCorporateAdvertCommandResponse(new SuccessfulContentResponse<CorporateAdvertDto>(corporateAdvertDto, ResponseTitles.Success, ResponseMessages.CorporateAdvertUpdated, System.Net.HttpStatusCode.OK));
        }

        private void SetCorporateAdvertDto(CorporateAdvertDto corporateAdvertDto, Advert advert, CorporateAdvert corporateAdvert)
        {
            corporateAdvertDto.AdvertId = advert.Id;
            corporateAdvertDto.CorporateAdvertId = corporateAdvert.Id;

            corporateAdvertDto.CorporateAdvertCorporateDealerId = corporateAdvert.CorporateDealerId;
            corporateAdvertDto.CorporateAdvertProductId = corporateAdvert.ProductId;
        }
    }
}
