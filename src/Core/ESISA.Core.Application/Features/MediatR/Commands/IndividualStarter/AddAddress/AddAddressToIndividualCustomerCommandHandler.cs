using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Adresses;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualStarter.AddAddress
{
    public class AddAddressToIndividualCustomerCommandHandler : IRequestHandler<AddAddressToIndividualCustomerCommandRequest, AddAddressToIndividualCustomerCommandResponse>
    {
        private readonly ICountryQueryRepository _countryQueryRepository;
        private readonly ICityQueryRepository _cityQueryRepository;
        private readonly IDistrictQueryRepository _districtQueryRepository;

        private readonly IAddressCommandRepository _addressCommandRepository;
        private readonly IAddressQueryRepository _addressQueryRepository;
        private readonly AddressBusinessRules _addressBusinessRules;

        private readonly IIndividualCustomerQueryRepository _individualCustomerQueryRepository;
        private readonly IndividualStarterBusinessRules _individualStarterBusinessRules;

        private readonly IIndividualCustomerAddressCommandRepository _individualCustomerAddressCommandRepository;
        private readonly IIndividualCustomerAddressQueryRepository _individualCustomerAddressQueryRepository;
        private readonly IndividualCustomerAddressBusinessRules _individualCustomerAddressBusinessRules;

        private readonly IMapper _mapper;

        public AddAddressToIndividualCustomerCommandHandler(ICountryQueryRepository countryQueryRepository, ICityQueryRepository cityQueryRepository, IDistrictQueryRepository districtQueryRepository, IAddressCommandRepository addressCommandRepository, IAddressQueryRepository addressQueryRepository, AddressBusinessRules addressBusinessRules, IIndividualCustomerQueryRepository individualCustomerQueryRepository, IndividualStarterBusinessRules individualStarterBusinessRules, IIndividualCustomerAddressCommandRepository individualCustomerAddressCommandRepository, IIndividualCustomerAddressQueryRepository individualCustomerAddressQueryRepository, IndividualCustomerAddressBusinessRules individualCustomerAddressBusinessRules, IMapper mapper)
        {
            _countryQueryRepository = countryQueryRepository;
            _cityQueryRepository = cityQueryRepository;
            _districtQueryRepository = districtQueryRepository;
            _addressCommandRepository = addressCommandRepository;
            _addressQueryRepository = addressQueryRepository;
            _addressBusinessRules = addressBusinessRules;
            _individualCustomerQueryRepository = individualCustomerQueryRepository;
            _individualStarterBusinessRules = individualStarterBusinessRules;
            _individualCustomerAddressCommandRepository = individualCustomerAddressCommandRepository;
            _individualCustomerAddressQueryRepository = individualCustomerAddressQueryRepository;
            _individualCustomerAddressBusinessRules = individualCustomerAddressBusinessRules;
            _mapper = mapper;
        }

        public async Task<AddAddressToIndividualCustomerCommandResponse> Handle(AddAddressToIndividualCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var indiviualCustomerToCheck = await _individualCustomerQueryRepository.GetByIdAsync(request.IndividualCustomerId);

            await _individualStarterBusinessRules.NullCheck(indiviualCustomerToCheck);


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

            Address address = null;

            await _addressBusinessRules.OnAddresNotExists(addressToCheck, async () =>
            {
                address = _mapper.Map<Address>(request);

                await _addressCommandRepository.AddAsync(address);
                await _addressCommandRepository.SaveChangesAsync();
            });

            var individualCustomerAddressToCheck = await _individualCustomerAddressQueryRepository.GetSingleAsync(e=>e.IndividualCustomerId == request.IndividualCustomerId && e.AddressId == address.Id);

            await _individualCustomerAddressBusinessRules.ExistsCheck(individualCustomerAddressToCheck);

            var individualCustomerAddress = new IndividualCustomerAddress()
            {
                IndividualCustomerId = request.IndividualCustomerId,
                AddressId = address.Id
            };

            await _individualCustomerAddressCommandRepository.AddAsync(individualCustomerAddress);
            await _individualCustomerAddressCommandRepository.SaveChangesAsync();

            var individualCustomerAddressDto = _mapper.Map<IndividualCustomerAddressDto>(individualCustomerAddress);

            return new AddAddressToIndividualCustomerCommandResponse(new SuccessfulContentResponse<IndividualCustomerAddressDto>(individualCustomerAddressDto, ResponseTitles.Success, ResponseMessages.IndividualCustomerAddressCreated, System.Net.HttpStatusCode.Created));
        }
    }
}
