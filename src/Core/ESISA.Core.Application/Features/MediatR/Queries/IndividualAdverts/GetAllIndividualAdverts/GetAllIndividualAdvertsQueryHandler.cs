using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Mappings.CustomMapper;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetAllIndividualAdverts
{
    public class GetAllIndividualAdvertsQueryHandler : IRequestHandler<GetAllIndividualAdvertsQueryRequest, GetAllIndividualAdvertsQueryResponse>
    {
        private readonly IAdvertQueryRepository _advertQueryRepository;
        private readonly IIndividualAdvertQueryRepository _individualAdvertQueryRepository;
        private readonly IndividualAdvertBusinessRules _individualAdvertBusinessRules;
        
        private readonly IMapper _mapper;

        public GetAllIndividualAdvertsQueryHandler(IAdvertQueryRepository advertQueryRepository,IIndividualAdvertQueryRepository individualAdvertQueryRepository, IndividualAdvertBusinessRules individualAdvertBusinessRules, IMapper mapper)
        {
            _advertQueryRepository = advertQueryRepository;
            _individualAdvertQueryRepository = individualAdvertQueryRepository;
            _individualAdvertBusinessRules = individualAdvertBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetAllIndividualAdvertsQueryResponse> Handle(GetAllIndividualAdvertsQueryRequest request, CancellationToken cancellationToken)
        {
            var individualAdverts = _individualAdvertQueryRepository.GetAll();

            await _individualAdvertBusinessRules.NullCheck(individualAdverts);

            var advertIds = individualAdverts.Select(e => e.AdvertId);

            var adverts = await this.SetIndividualAdvertsToAdvertsAsync(individualAdverts);

            var individualAdvertDtos = CustomMappingTool.MapIndividualAdvertDtosWithCustomMapper(adverts, individualAdverts.ToList());

            var paginate = individualAdvertDtos.ToPaginate<IndividualAdvertDto>(request.PageIndex, request.PageSize);

            return new GetAllIndividualAdvertsQueryResponse(new SuccessfulContentResponse<IPaginate<IndividualAdvertDto>>(paginate, ResponseTitles.Success, ResponseMessages.IndividualAdvertsListed, System.Net.HttpStatusCode.OK));
        }

        private async Task<List<Advert>> SetIndividualAdvertsToAdvertsAsync(IQueryable<IndividualAdvert> individualAdverts)
        {
            var advertIds = individualAdverts.Select(e => e.AdvertId).ToList();

            List<Advert> adverts = new List<Advert>();

            foreach (var advertId in advertIds)
            {
                var advert = await _advertQueryRepository.GetByIdAsync(advertId);

                adverts.Add(advert);
            }

            return adverts;
        }
    }
}
