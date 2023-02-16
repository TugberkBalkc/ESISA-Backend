using ESISA.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Advert
{
    public class CreateIndividualAdvertDto
    {
        public String AdvertTitle { get; set; }
        public String AdvertDescription { get; set; }

        public Guid IndividualAdvertIndividualDealerId { get; set; }
        public Guid IndividualAdvertProductId { get; set; }

        public decimal IndividualAdvertPrice { get; set; }
        public bool IndividualAdvertBargain { get; set; }
        public ProductConditionType IndividualAdvertProductConditionType { get; set; }

        public CreateIndividualAdvertDto()
        {

        }

        public CreateIndividualAdvertDto(string advertTitle, string advertDescription, Guid individualAdvertIndividualDealerId, Guid individualAdvertProductId, decimal individualAdvertPrice, bool individualAdvertBargain, ProductConditionType individualAdvertProductConditionType)
        {
            AdvertTitle = advertTitle;
            AdvertDescription = advertDescription;
            IndividualAdvertIndividualDealerId = individualAdvertIndividualDealerId;
            IndividualAdvertProductId = individualAdvertProductId;
            IndividualAdvertPrice = individualAdvertPrice;
            IndividualAdvertBargain = individualAdvertBargain;
            IndividualAdvertProductConditionType = individualAdvertProductConditionType;
        }

    }
}
