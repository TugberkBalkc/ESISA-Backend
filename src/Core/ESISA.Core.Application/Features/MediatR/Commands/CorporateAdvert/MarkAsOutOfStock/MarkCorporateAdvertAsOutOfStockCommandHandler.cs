using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.CorporateAdverts;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Mappings.CustomMapper;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.MarkAsOutOfStock
{
    public class MarkCorporateAdvertAsOutOfStockCommandHandler :
        IRequestHandler<MarkCorporateAdvertAsOutOfStockCommandRequest, MarkCorporateAdvertAsOutOfStockCommandResponse>
    {
        private readonly IAdvertQueryRepository _advertQueryRepository;
        private readonly ICorporateAdvertCommandRepository _corporateAdvertCommandRepository;
        private readonly ICorporateAdvertQueryRepository _corporateAdvertQueryRepository;
        private readonly CorporateAdvertBusinessRules _corporateAdvertBusinessRules;

        public MarkCorporateAdvertAsOutOfStockCommandHandler(IAdvertQueryRepository advertQueryRepository, ICorporateAdvertCommandRepository corporateAdvertCommandRepository, ICorporateAdvertQueryRepository corporateAdvertQueryRepository, CorporateAdvertBusinessRules corporateAdvertBusinessRules)
        {
            _advertQueryRepository = advertQueryRepository;
            _corporateAdvertCommandRepository = corporateAdvertCommandRepository;
            _corporateAdvertQueryRepository = corporateAdvertQueryRepository;
            _corporateAdvertBusinessRules = corporateAdvertBusinessRules;
        }

        public async Task<MarkCorporateAdvertAsOutOfStockCommandResponse> Handle(MarkCorporateAdvertAsOutOfStockCommandRequest request, CancellationToken cancellationToken)
        {
            var corporateAdvert = await _corporateAdvertQueryRepository.GetSingleAsync(e => e.Id == request.CorporateAdvertId);

            await _corporateAdvertBusinessRules.NullCheck(corporateAdvert);
            await _corporateAdvertBusinessRules.CheckIfCorporateAdvertAlreadyOutOfStock(corporateAdvert);

            corporateAdvert.IsActive = false;
            corporateAdvert.StockAmount = 0;

            _corporateAdvertCommandRepository.Update(corporateAdvert);
            await _corporateAdvertCommandRepository.SaveChangesAsync();

            var advert = await _advertQueryRepository.GetSingleAsync(e => e.Id == corporateAdvert.AdvertId);

            var corporateAdvertDto = CustomMappingTool.MapToCorporateAdvertDto(advert, corporateAdvert);

            return new MarkCorporateAdvertAsOutOfStockCommandResponse(new SuccessfulContentResponse<CorporateAdvertDto>(corporateAdvertDto, ResponseTitles.Success, ResponseMessages.AdvertMarkedAsOutOfStock, System.Net.HttpStatusCode.OK));
        }
    }
}
