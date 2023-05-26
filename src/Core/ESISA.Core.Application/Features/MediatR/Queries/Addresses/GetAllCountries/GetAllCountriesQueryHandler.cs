using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Adresses;
using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllCities;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Rules.BusinessRules.Common;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllCountries
{
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQueryRequest, GetAllCountriesQueryResponse>
    {
        private readonly ICountryQueryRepository _countryQueryRepository;
        private readonly IMapper _mapper;
        private readonly CountryBusinessRules _countryBusinessRules;

        public GetAllCountriesQueryHandler(ICountryQueryRepository countryQueryRepository, IMapper mapper, CountryBusinessRules countryBusinessRules)
        {
            _countryQueryRepository = countryQueryRepository;   
            _mapper = mapper;   
            _countryBusinessRules = countryBusinessRules;   

        }

        public async Task<GetAllCountriesQueryResponse> Handle(GetAllCountriesQueryRequest request, CancellationToken cancellationToken)
        {
            var countryDtos = _countryQueryRepository.GetAll().OrderBy(e => e.Name).Select(e => _mapper.Map<CountryDto>(e));

            await _countryBusinessRules.NullCheck(countryDtos);

            var paginate = countryDtos.ToPaginate<CountryDto>(request.PageIndex, request.PageSize);

            return new GetAllCountriesQueryResponse(new SuccessfulContentResponse<IPaginate<CountryDto>>(paginate, ResponseTitles.Success, "", System.Net.HttpStatusCode.OK));
        }
    }
}
