using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Adresses;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Addresses.Create
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommandRequest, CreateAddressCommandResponse>
    {
        private readonly IAddressCommandRepository _addressCommandRepository;
        private readonly IAddressQueryRepository _addressQueryRepository;
        private readonly AddressBusinessRules _addressBusinessRules;

        private readonly ICountryQueryRepository _countryQueryRepository;
        private readonly ICityQueryRepository _cityQueryRepository;
        private readonly IDistrictQueryRepository _districtQueryRepository;

        private readonly IMapper _mapper;

        public CreateAddressCommandHandler(IAddressCommandRepository addressCommandRepository, IAddressQueryRepository addressQueryRepository, AddressBusinessRules addressBusinessRules, ICountryQueryRepository countryQueryRepository, ICityQueryRepository cityQueryRepository, IDistrictQueryRepository districtQueryRepository, IMapper mapper)
        {
            _addressCommandRepository = addressCommandRepository;
            _addressQueryRepository = addressQueryRepository;
            _addressBusinessRules = addressBusinessRules;
            _countryQueryRepository = countryQueryRepository;
            _cityQueryRepository = cityQueryRepository;
            _districtQueryRepository = districtQueryRepository;
            _mapper = mapper;
        }

        public async Task<CreateAddressCommandResponse> Handle(CreateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var country = await _countryQueryRepository.GetByIdAsync(request.AddressCountryId);

            await _addressBusinessRules.NullCheck(country);

            var city = await _cityQueryRepository.GetByIdAsync(request.AddressCityId);

            await _addressBusinessRules.NullCheck(city);

            var district = await _districtQueryRepository.GetByIdAsync(request.AddressDistrictId);

            await _addressBusinessRules.NullCheck(district);

            var addressToCheck = await _addressQueryRepository.GetSingleAsync(e => e.CountryId == request.AddressCountryId &&
                                                                                   e.CityId == request.AddressCityId &&
                                                                                   e.DistrictId == request.AddressDistrictId &&
                                                                                   e.Details == request.AddressDetails);

            await _addressBusinessRules.ExistsCheck(addressToCheck);

            var address = _mapper.Map<Address>(request);

            await _addressCommandRepository.AddAsync(address);
            await _addressCommandRepository.SaveChangesAsync();

            var addressDto = _mapper.Map<AddressDto>(address);

            return new CreateAddressCommandResponse(new SuccessfulContentResponse<AddressDto>(addressDto, ResponseTitles.Success, ResponseMessages.AddressCreated, System.Net.HttpStatusCode.OK));
        }
    }
}
