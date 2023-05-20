using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Adress
{
    public class AdressDto
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
        public Guid DistrictId { get; set; }

        public String PostalCode { get; set; }
        public String Details { get; set; }

        public AdressDto()
        {

        }
        public AdressDto(Guid id,Guid countryId,Guid cityId, Guid districtId, string postalCode, string details)
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
