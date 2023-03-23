using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Adress
{
    public class DistrictDto
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public String Name { get; set; }
        public DistrictDto()
        {


        }
        public DistrictDto(Guid id,Guid cityId, string name)
        {
            Id = id;    
            CityId = cityId;    
            Name = name;

        }
    }
}
