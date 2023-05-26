using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Adresses
{
    public class IndividualCustomerAddressDto
    {
        public Guid Id { get; set; }    
        public Guid IndividualCustomerId { get; set; }
        public Guid AddressId { get; set; }

        public bool IsResidence { get; set; }

        public IndividualCustomerAddressDto()
        {

        }
        public IndividualCustomerAddressDto(Guid individualCustomerId, Guid addressId, bool isResidence, Guid id)
        {
            IndividualCustomerId = individualCustomerId;    
            AddressId = addressId;  
            IsResidence = isResidence;  
            Id = id;    

        }
    }
}
