using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.CorporateAdverts;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Mappings.CustomMapper;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.UpdateStock
{
    public class UpdateCorporateAdvertStockCommandHandler : IRequestHandler<UpdateCorporateAdvertStockCommandRequest, UpdateCorporateAdvertStockCommandResponse>
    {
        private readonly IAdvertQueryRepository _advertQueryRepository;

        private readonly ICorporateAdvertCommandRepository _corporateAdvertCommandRepository;
        private readonly ICorporateAdvertQueryRepository _corporateAdvertQueryRepository;
        private readonly CorporateAdvertBusinessRules _corporateAdvertBusinessRules;

        public UpdateCorporateAdvertStockCommandHandler(IAdvertQueryRepository advertQueryRepository, ICorporateAdvertCommandRepository corporateAdvertCommandRepository, ICorporateAdvertQueryRepository corporateAdvertQueryRepository, CorporateAdvertBusinessRules corporateAdvertBusinessRules)
        {
            _advertQueryRepository = advertQueryRepository;

            _corporateAdvertCommandRepository = corporateAdvertCommandRepository;
            _corporateAdvertQueryRepository = corporateAdvertQueryRepository;
            _corporateAdvertBusinessRules = corporateAdvertBusinessRules;
        }
        public async Task<UpdateCorporateAdvertStockCommandResponse> Handle(UpdateCorporateAdvertStockCommandRequest request, CancellationToken cancellationToken)
        {
            var corporateAdvert = await _corporateAdvertQueryRepository.GetSingleAsync(e => e.Id == request.CorporateAdvertId);

            await _corporateAdvertBusinessRules.NullCheck(corporateAdvert);
            await _corporateAdvertBusinessRules.CheckIfCorporateAdvertSold(corporateAdvert);

            corporateAdvert.StockAmount = request.UpdatedStockAmount;

            _corporateAdvertCommandRepository.Update(corporateAdvert);
            await _corporateAdvertCommandRepository.SaveChangesAsync();

            var advert = await _advertQueryRepository.GetSingleAsync(e => e.Id == corporateAdvert.AdvertId);

            var corporateAdvertDto = CustomMappingTool.MapToCorporateAdvertDto(advert, corporateAdvert);

            return new UpdateCorporateAdvertStockCommandResponse(new SuccessfulContentResponse<CorporateAdvertDto>(corporateAdvertDto, ResponseTitles.Success, ResponseMessages.PriceUpdated, System.Net.HttpStatusCode.OK));
        }
    }
}
