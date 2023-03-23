using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Adress
{
    public class CityDto
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public String Name { get; set; }
        public CityDto()
        {

        }
        public CityDto(Guid id , Guid countryId, string name)
        {
            Id = id;    
            CountryId = countryId;  
            Name = name;
        }
    }
}
