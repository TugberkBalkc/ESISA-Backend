using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Update;
using ESISA.Core.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.Update
{
    public class UpdateSwapAdvertCommandRequest : IRequest<UpdateSwapAdvertCommandResponse>
    {
        public Guid AdvertId { get; set; }
        public Guid SwapAdvertId { get; set; }
        public String AdvertTitle { get; set; }
        public String AdvertDescription { get; set; }
        public ProductConditionType SwapAdvertProductConditionType { get; set; }

        public UpdateSwapAdvertCommandRequest()
        {

        }

        public UpdateSwapAdvertCommandRequest(Guid advertId, Guid swapAdvertId, string advertTitle, string advertDescription, ProductConditionType swapAdvertProductConditionType)
        {
            AdvertId = advertId;
            SwapAdvertId = swapAdvertId;
            AdvertTitle = advertTitle;
            AdvertDescription = advertDescription;
            SwapAdvertProductConditionType = swapAdvertProductConditionType;
        }
    }
}
