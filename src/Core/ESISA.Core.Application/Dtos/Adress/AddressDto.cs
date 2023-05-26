using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Adresses
{
    public class AddressDto
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
        public Guid DistrictId { get; set; }

        public String PostalCode { get; set; }
        public String Details { get; set; }

        public AddressDto()
        {

        }
        public AddressDto(Guid id,Guid countryId,Guid cityId, Guid districtId, string postalCode, string details)
        {
            Id=id;  
            CountryId=countryId;    
            CityId=cityId;  
            DistrictId=districtId;
            PostalCode=postalCode;  
            Details=details;    

        }
    }
}
