using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Adresses
{
    public class AddressDetailsDto
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string CountryName { get; set; }
        public Guid CityId { get; set; }
        public string CityName { get; set; }
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string Details { get; set; }
        public String PostalCode { get; set; }

        public AddressDetailsDto()
        {


        }
      

        public AddressDetailsDto(Guid id, Guid countryId, string countryName, Guid cityId, string cityName, Guid districtId, string districtName, string details, string postalCode)
        {
            Id = id;
            CountryId = countryId;
            CountryName = countryName;
            CityId = cityId;
            CityName = cityName;
            DistrictId = districtId;
            DistrictName = districtName;
            Details = details;
            PostalCode = postalCode;
        }
    }
}
