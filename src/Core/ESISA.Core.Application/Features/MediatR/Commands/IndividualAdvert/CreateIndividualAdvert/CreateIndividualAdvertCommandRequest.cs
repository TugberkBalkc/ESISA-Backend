using ESISA.Core.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.CreateIndividualAdvert
{
    public class CreateIndividualAdvertCommandRequest : IRequest<CreateIndividualAdvertCommandResponse>
    {
        public String AdvertTitle { get; set; }
        public String AdvertDescription { get; set; }

        public Guid IndividualAdvertIndividualDealerId { get; set; }
        public Guid IndividualAdvertProductId { get; set; }

        public decimal IndividualAdvertPrice { get; set; }<
        public bool IndividualAdvertBargain { get; set; }
        public ProductConditionType IndividualAdvertProductConditionType { get; set; }

        public CreateIndividualAdvertCommandRequest()
        {

        }

        public CreateIndividualAdvertCommandRequest(string advertTitle, string advertDescription, Guid ındividualAdvertIndividualDealerId, Guid ındividualAdvertProductId, decimal ındividualAdvertPrice, bool ındividualAdvertBargain, ProductConditionType ındividualAdvertProductConditionType)
        {
            AdvertTitle = advertTitle;
            AdvertDescription = advertDescription;
            IndividualAdvertIndividualDealerId = ındividualAdvertIndividualDealerId;
            IndividualAdvertProductId = ındividualAdvertProductId;
            IndividualAdvertPrice = ındividualAdvertPrice;
            IndividualAdvertBargain = ındividualAdvertBargain;
            IndividualAdvertProductConditionType = ındividualAdvertProductConditionType;
        }
    }
}
