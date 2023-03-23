using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Adress
{
    public class CountryDto
    {
        public Guid Id { get; set; }
        public String Name { get; set; }

        public CountryDto()
        {

        }
        public CountryDto(Guid id,string name)
        {
            Id = id;    
            Name = name;    

        }
    }
}
