using ESISA.Core.Application.Dtos.Advert.Common;
using ESISA.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Advert.IndividualAdvert
{
    public class IndividualAdvertDetailsDto : AdvertDto
    {
        public Guid IndividualAdvertId { get; set; }
        public bool IsIndividualAdvertActive { get; set; }
        public bool IsIndividualAdvertSold => !this.IsIndividualAdvertActive;
        public int AdvertsFavoriteCount { get; set; }


        public Guid IndividualAdvertIndividualDealerId { get; set; }
        public String IndividualAdvertIndividualDealerFirstName { get; set; }
        public String IndividualAdvertIndividualDealerLastName { get; set; }


        public Guid IndividualAdvertProductId { get; set; }
        public String IndividualAdvertProductName { get; set; }

        public String IndividualAdvertProductBrandId { get; set; }
        public String IndividualAdvertProductBrandName { get; set; }

        public Guid IndividualAdvertProductCategoryId { get; set; }
        public String IndividualAdvertProductCategoryName { get; set; }


        public decimal IndividualAdvertPrice { get; set; }
        public bool IndividualAdvertBargain { get; set; }
        public ProductConditionType IndividualAdvertProductConditionType { get; set; }

     
    }
}
