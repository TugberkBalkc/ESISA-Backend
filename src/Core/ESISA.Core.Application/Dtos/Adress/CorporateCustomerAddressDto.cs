using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Adress
{
    public class CorporateCustomerAddressDto
    {
        public Guid CorporateCustomerId { get; set; }
        public Guid AddressId { get; set; }

        public bool IsCenterCompany { get; set; }

        public CorporateCustomerAddressDto()
        {


        }
        public CorporateCustomerAddressDto(Guid corporateCustomerId, Guid addressId, bool isCenterCompany)
        {
            CorporateCustomerId = corporateCustomerId;
            AddressId = addressId;  
            IsCenterCompany = isCenterCompany;  
        }

    }
}
