using ESISA.Core.Application.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Adresses
{
    public class IndividualCustomerAddressDetailsDto
    {
        public Guid Id { get; set; }    

        public Guid IndividualCustomerId { get; set; }
        public String IndividualCustomerFirstName { get; set; }
        public String IndividualCustomerLastName { get; set; }

        public Guid AddressId { get; set; }
        public Guid CountryId { get; set; }
        public string CountryName { get; set; }
        public Guid CityId { get; set; }
        public string CityName { get; set; }
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string Details { get; set; }
        public String PostalCode { get; set; }

        public bool IsResidence { get; set; }

        public AddressDetailsDto AdressDetailsDto { get; set; }

     //   public IndividualCustomerDto IndividualCustomerDto { get; set; }

        public IndividualCustomerAddressDetailsDto()
        {

        }
        public IndividualCustomerAddressDetailsDto(Guid individualCustomerId, AddressDetailsDto adressDetailsDto, 
            bool isResidence, Guid addressId,/* IndividualCustomerDto indvidualCustomerDto,*/ Guid id)
        {
            Id = id;
         //   IndividualCustomerDto = indvidualCustomerDto;
            AddressId = addressId;    
            IsResidence = isResidence;    
            AddressId = addressId;
            IndividualCustomerId = individualCustomerId;
        }
    }
}
