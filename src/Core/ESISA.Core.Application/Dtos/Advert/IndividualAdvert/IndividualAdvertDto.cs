using ESISA.Core.Application.Dtos.Advert.Common;
using ESISA.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Advert.IndividualAdverts
{
    public class IndividualAdvertDto : AdvertDto
    {
        public bool IsIndividualAdvertSold 
        {
            get 
            {
                return !this.IsIndividualAdvertActive;
            } 
        }

        public bool IsIndividualAdvertActive { get; set; }

        public Guid IndividualAdvertIndividualDealerId { get; set; }
        public Guid IndividualAdvertProductId { get; set; }

        public decimal IndividualAdvertPrice { get; set; }
        public bool IndividualAdvertBargain { get; set; }
        public ProductConditionType IndividualAdvertProductConditionType { get; set; }
    }
}
