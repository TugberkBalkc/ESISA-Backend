using ESISA.Core.Application.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Adress
{
    public class IndividualCustomerAddressDetailsDto
    {
        public Guid Id { get; set; }    
        public Guid IndividualCustomerId { get; set; }
        public Guid AddressId { get; set; }

        public bool IsResidence { get; set; }

        public AdressDetailsDto AdressDetailsDto { get; set; }

        public IndividualCustomerDto IndividualCustomerDto { get; set; }

        public IndividualCustomerAddressDetailsDto()
        {

        }
        public IndividualCustomerAddressDetailsDto(Guid individualCustomerId, AdressDetailsDto adressDetailsDto, 
            bool isResidence, Guid addressId, IndividualCustomerDto indvidualCustomerDto, Guid id)
        {
            Id = id;
            IndividualCustomerDto = indvidualCustomerDto;
            AddressId = addressId;    
            IsResidence = isResidence;    
            AddressId = addressId;
            IndividualCustomerId = individualCustomerId;
        }
    }
}
