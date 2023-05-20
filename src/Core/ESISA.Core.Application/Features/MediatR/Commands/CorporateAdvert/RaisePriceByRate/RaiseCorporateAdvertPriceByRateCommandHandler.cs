using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.CorporateAdverts;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Mappings.CustomMapper;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Common;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.RaisePriceByRate
{
    public class RaiseCorporateAdvertPriceByRateCommandHandler : IRequestHandler<RaiseCorporateAdvertPriceByRateCommandRequest, RaiseCorporateAdvertPriceByRateCommandResponse>
    {
        private readonly IAdvertQueryRepository _advertQueryRepository;

        private readonly ICorporateAdvertCommandRepository _corporateAdvertCommandRepository;
        private readonly ICorporateAdvertQueryRepository _corporateAdvertQueryRepository;
        private readonly CorporateAdvertBusinessRules _corporateAdvertBusinessRules;

        public RaiseCorporateAdvertPriceByRateCommandHandler(IAdvertQueryRepository advertQueryRepository, ICorporateAdvertCommandRepository corporateAdvertCommandRepository, ICorporateAdvertQueryRepository corporateAdvertQueryRepository, CorporateAdvertBusinessRules corporateAdvertBusinessRules)
        {
            _advertQueryRepository = advertQueryRepository;

            _corporateAdvertCommandRepository = corporateAdvertCommandRepository;
            _corporateAdvertQueryRepository = corporateAdvertQueryRepository;
            _corporateAdvertBusinessRules = corporateAdvertBusinessRules;
        }

        public async Task<RaiseCorporateAdvertPriceByRateCommandResponse> Handle(RaiseCorporateAdvertPriceByRateCommandRequest request, CancellationToken cancellationToken)
        {
            var corporateAdvert = await _corporateAdvertQueryRepository.GetSingleAsync(e => e.Id == request.CorporateAdvertId);

            await _corporateAdvertBusinessRules.NullCheck(corporateAdvert);
            await _corporateAdvertBusinessRules.CheckIfCorporateAdvertSold(corporateAdvert);

            corporateAdvert.UnitPrice = PriceChangeUtility.RaisePriceByRate(corporateAdvert.UnitPrice, Convert.ToDecimal(request.RaiseRate));

            _corporateAdvertCommandRepository.Update(corporateAdvert);
            await _corporateAdvertCommandRepository.SaveChangesAsync();

            var advert = await _advertQueryRepository.GetSingleAsync(e => e.Id == corporateAdvert.AdvertId);

            var corporateAdvertDto = CustomMappingTool.MapToCorporateAdvertDto(advert, corporateAdvert);

            return new RaiseCorporateAdvertPriceByRateCommandResponse(new SuccessfulContentResponse<CorporateAdvertDto>(corporateAdvertDto, ResponseTitles.Success, ResponseMessages.PriceRaised, System.Net.HttpStatusCode.OK));
        }
    }
}
