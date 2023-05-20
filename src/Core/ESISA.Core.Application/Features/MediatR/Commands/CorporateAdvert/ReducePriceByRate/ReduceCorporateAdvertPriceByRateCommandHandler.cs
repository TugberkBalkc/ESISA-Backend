using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.CorporateAdverts;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Mappings.CustomMapper;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Common;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.ReducePriceByRate
{
    public class ReduceCorporateAdvertPriceByRateCommandHandler : IRequestHandler<ReduceCorporateAdvertPriceByRateCommandRequest, ReduceCorporateAdvertPriceByRateCommandResponse>
    {
        private readonly IAdvertQueryRepository _advertQueryRepository;

        private readonly ICorporateAdvertCommandRepository _corporateAdvertCommandRepository;
        private readonly ICorporateAdvertQueryRepository _corporateAdvertQueryRepository;
        private readonly CorporateAdvertBusinessRules _corporateAdvertBusinessRules;

        public ReduceCorporateAdvertPriceByRateCommandHandler(IAdvertQueryRepository advertQueryRepository, ICorporateAdvertCommandRepository corporateAdvertCommandRepository, ICorporateAdvertQueryRepository corporateAdvertQueryRepository, CorporateAdvertBusinessRules corporateAdvertBusinessRules)
        {
            _advertQueryRepository = advertQueryRepository;

            _corporateAdvertCommandRepository = corporateAdvertCommandRepository;
            _corporateAdvertQueryRepository = corporateAdvertQueryRepository;
            _corporateAdvertBusinessRules = corporateAdvertBusinessRules;
        }
        public async Task<ReduceCorporateAdvertPriceByRateCommandResponse> Handle(ReduceCorporateAdvertPriceByRateCommandRequest request, CancellationToken cancellationToken)
        {
            var corporateAdvert = await _corporateAdvertQueryRepository.GetSingleAsync(e => e.Id == request.CorporateAdvertId);

            await _corporateAdvertBusinessRules.NullCheck(corporateAdvert);
            await _corporateAdvertBusinessRules.CheckIfCorporateAdvertSold(corporateAdvert);

            corporateAdvert.UnitPrice = PriceChangeUtility.ReducePriceByRate(corporateAdvert.UnitPrice, Convert.ToDecimal(request.ReduceRate));

            _corporateAdvertCommandRepository.Update(corporateAdvert);
            await _corporateAdvertCommandRepository.SaveChangesAsync();

            var advert = await _advertQueryRepository.GetSingleAsync(e => e.Id == corporateAdvert.AdvertId);

            var corporateAdvertDto = CustomMappingTool.MapToCorporateAdvertDto(advert, corporateAdvert);

            return new ReduceCorporateAdvertPriceByRateCommandResponse(new SuccessfulContentResponse<CorporateAdvertDto>(corporateAdvertDto, ResponseTitles.Success, ResponseMessages.PriceReduced, System.Net.HttpStatusCode.OK));
        }
    }
}
