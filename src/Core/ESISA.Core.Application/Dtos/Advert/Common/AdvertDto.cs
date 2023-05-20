using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Advert.Common
{
    public class AdvertDto
    {
        public Guid AdvertId { get; set; }
        public String AdvertTitle { get; set; }
        public String AdvertDescription { get; set; }

    }
}
