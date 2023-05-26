using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Adresses;
using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllCities;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllCitiesByCountryId
{
    public class GetAllCitiesByCountryIdQueryHandler : IRequestHandler<GetAllCitiesByCountryIdQueryRequest, GetAllCitiesByCountryIdQueryResponse>
    {
        private readonly ICityQueryRepository _cityQueryRepository;
        private readonly IMapper _mapper;
        private readonly CityBusinessRules _cityBusinessRules;

        public GetAllCitiesByCountryIdQueryHandler(ICityQueryRepository cityQueryRepository, IMapper mapper, CityBusinessRules cityBusinessRules)
        {
            _cityQueryRepository = cityQueryRepository;
            _mapper = mapper;
            _cityBusinessRules = cityBusinessRules;
        }

        public async Task<GetAllCitiesByCountryIdQueryResponse> Handle(GetAllCitiesByCountryIdQueryRequest request, CancellationToken cancellationToken)
        {
            var cityDtos = _cityQueryRepository.GetAll()
                .Where(e=>e.CountryId==request.CountryId).
                OrderBy(e => e.Name)
                .Select(e => _mapper.Map<CityDto>(e));

            await _cityBusinessRules.NullCheck(cityDtos);

            var paginate = cityDtos.ToPaginate<CityDto>(request.PageIndex, request.PageSize);

            return new GetAllCitiesByCountryIdQueryResponse(new SuccessfulContentResponse<IPaginate<CityDto>>(paginate, ResponseTitles.Success, "", System.Net.HttpStatusCode.OK));
        }

    }
}
