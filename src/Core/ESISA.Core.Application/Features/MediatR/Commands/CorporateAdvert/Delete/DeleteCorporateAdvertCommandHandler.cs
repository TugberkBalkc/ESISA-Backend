using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.Delete
{
    public class DeleteCorporateAdvertCommandHandler : IRequestHandler<DeleteCorporateAdvertCommandRequest, DeleteCorporateAdvertCommandResponse>
    {
        private readonly IAdvertCommandRepository _advertCommandRepository;
        private readonly IAdvertQueryRepository _advertQueryRepository;
        private readonly ICorporateAdvertCommandRepository _corporateAdvertCommandRepository;
        private readonly ICorporateAdvertQueryRepository _corporateAdvertQueryRepository;
        private readonly CorporateAdvertBusinessRules _corporateAdvertBusinessRules;
        private readonly IMapper _mapper;

        public DeleteCorporateAdvertCommandHandler(IAdvertCommandRepository advertCommandRepository, IAdvertQueryRepository advertQueryRepository, ICorporateAdvertCommandRepository corporateAdvertCommandRepository, ICorporateAdvertQueryRepository corporateAdvertQueryRepository, CorporateAdvertBusinessRules corporateAdvertBusinessRules, IMapper mapper)
        {
            _advertCommandRepository = advertCommandRepository;
            _advertQueryRepository = advertQueryRepository;
            _corporateAdvertCommandRepository = corporateAdvertCommandRepository;
            _corporateAdvertQueryRepository = corporateAdvertQueryRepository;
            _corporateAdvertBusinessRules = corporateAdvertBusinessRules;
            _mapper = mapper;
        }

        public async Task<DeleteCorporateAdvertCommandResponse> Handle(DeleteCorporateAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            var corporateAdvert = await _corporateAdvertQueryRepository.GetSingleAsync(e => e.Id == request.CorporateAdvertId);

            await _corporateAdvertBusinessRules.NullCheck(corporateAdvert);

            var advert = await _advertQueryRepository.GetSingleAsync(e => e.Id == corporateAdvert.AdvertId);

            await _corporateAdvertBusinessRules.NullCheck(advert);

            _corporateAdvertCommandRepository.Delete(corporateAdvert);
            await _corporateAdvertCommandRepository.SaveChangesAsync();

            _advertCommandRepository.Delete(advert);
            await _advertCommandRepository.SaveChangesAsync();

            return new DeleteCorporateAdvertCommandResponse(new SuccessfulContentResponse<Guid>(corporateAdvert.Id, ResponseTitles.Success, ResponseMessages.CorporateAdvertDeleted, System.Net.HttpStatusCode.OK));
        }
    }
}
