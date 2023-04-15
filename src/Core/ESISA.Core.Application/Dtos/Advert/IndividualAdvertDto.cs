using ESISA.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Advert
{
    public class IndividualAdvertDto
    {
        
        public Guid AdvertId { get; set; }
        public Guid IndividualAdvertId { get; set; }

        public DateTime AdvertCreatedDate { get; set; }
        public DateTime AdvertModifiedDate { get; set; }
        public bool AdvertIsActive { get; set; }
        public bool AdvertIsDeleted { get; set; }
     
        public String AdvertTitle { get; set; }
        public String AdvertDescription { get; set; }

        public Guid IndividualAdvertIndividualDealerId { get; set; }
        public Guid IndividualAdvertProductId { get; set; }

        public decimal IndividualAdvertPrice { get; set; }
        public bool IndividualAdvertBargain { get; set; }
        public ProductConditionType IndividualAdvertProductConditionType { get; set; }
    }
}
