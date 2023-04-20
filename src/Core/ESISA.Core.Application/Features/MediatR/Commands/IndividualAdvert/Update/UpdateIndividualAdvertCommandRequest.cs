using ESISA.Core.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Update
{
    public class UpdateIndividualAdvertCommandRequest : IRequest<UpdateIndividualAdvertCommandResponse>
    {
        public Guid AdvertId { get; set; }
        public Guid IndividualAdvertId { get; set; }

        public String? AdvertTitle { get; set; }
        public String? AdvertDescription { get; set; }

        public decimal? IndividualAdvertPrice { get; set; }
        public bool? IndividualAdvertBargain { get; set; }
        public ProductConditionType? IndividualAdvertProductConditionType { get; set; }

        public UpdateIndividualAdvertCommandRequest()
        {

        }

        public UpdateIndividualAdvertCommandRequest(Guid advertId, Guid individualAdvertId, string advertTitle, string advertDescription, decimal individualAdvertPrice, bool individualAdvertBargain, ProductConditionType individualAdvertProductConditionType)
        {
            AdvertTitle = advertTitle;
            AdvertDescription = advertDescription;
            IndividualAdvertPrice = individualAdvertPrice;
            IndividualAdvertBargain = individualAdvertBargain;
            IndividualAdvertProductConditionType = individualAdvertProductConditionType;
        }
    }
}
