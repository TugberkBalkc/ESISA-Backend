using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Adresses
{
    public class CorporateCustomerAddressDetailsDto
    {
        public Guid CorporateCustomerId { get; set; }
        public Guid AddressId { get; set; }

        public bool IsCenterCompany { get; set; }


    }
}
