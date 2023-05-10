using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Create;
using ESISA.Core.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.Create
{
    public class CreateSwapAdvertCommandRequest : IRequest<CreateSwapAdvertCommandResponse>
    {
        public String AdvertTitle { get; set; }
        public String AdvertDescription { get; set; }
        public Guid SwapAdvertIndividualDealerId { get; set; }
        public Guid SwapAdvertProductId { get; set; }
        public ProductConditionType SwapAdvertProductConditionType { get; set; }

        public CreateSwapAdvertCommandRequest()
        {

        }

        public CreateSwapAdvertCommandRequest(string advertTitle, string advertDescription, Guid swapAdvertIndividualDealerId, Guid swapAdvertProductId, ProductConditionType swapAdvertProductConditionType)
        {
            AdvertTitle = advertTitle;
            AdvertDescription = advertDescription;
            SwapAdvertIndividualDealerId = swapAdvertIndividualDealerId;
            SwapAdvertProductId = swapAdvertProductId;
            SwapAdvertProductConditionType = swapAdvertProductConditionType;
        }
    }
}
