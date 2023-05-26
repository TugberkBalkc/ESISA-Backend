using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualStarter.AddAddress
{
    public class AddAddressToIndividualCustomerCommandRequest : IRequest<AddAddressToIndividualCustomerCommandResponse>
    {
        public Guid AddressCountryId { get; set; }
        public Guid AddressCityId { get; set; }
        public Guid AddressDistrictId { get; set; }

        public String AddressPostalCode { get; set; }
        public String AddressDetails { get; set; }

        public Guid IndividualCustomerId { get; set; }

        public AddAddressToIndividualCustomerCommandRequest()
        {

        }

        public AddAddressToIndividualCustomerCommandRequest(Guid addressCountryId, Guid addressCityId, Guid addressDistrictId, string addressPostalCode, string addressDetails, Guid ındividualCustomerId)
        {
            AddressCountryId = addressCountryId;
            AddressCityId = addressCityId;
            AddressDistrictId = addressDistrictId;
            AddressPostalCode = addressPostalCode;
            AddressDetails = addressDetails;
            IndividualCustomerId = ındividualCustomerId;
        }
    }
}
