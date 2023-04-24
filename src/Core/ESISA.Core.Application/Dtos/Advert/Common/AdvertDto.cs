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

        public DateTime AdvertCreatedDate { get; set; }
        public DateTime AdvertModifiedDate { get; set; }
        public bool AdvertIsActive { get; set; }
        public bool AdvertIsDeleted { get; set; }

        public String AdvertTitle { get; set; }
        public String AdvertDescription { get; set; }

    }
}
