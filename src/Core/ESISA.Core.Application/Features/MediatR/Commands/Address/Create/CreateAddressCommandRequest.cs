using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Addresses.Create
{
    public class CreateAddressCommandRequest : IRequest<CreateAddressCommandResponse>
    {
        public Guid AddressCountryId { get; set; }
        public Guid AddressCityId { get; set; }
        public Guid AddressDistrictId { get; set; }

        public String AddressPostalCode { get; set; }
        public String AddressDetails { get; set; }

        public CreateAddressCommandRequest()
        {

        }

        public CreateAddressCommandRequest(Guid addressCountryId, Guid addressCityId, Guid addressDistrictId, string addressPostalCode, string addressDetails)
        {
            AddressCountryId = addressCountryId;
            AddressCityId = addressCityId;
            AddressDistrictId = addressDistrictId;
            AddressPostalCode = addressPostalCode;
            AddressDetails = addressDetails;
        }
    }
}
