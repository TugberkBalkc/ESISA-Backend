using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.UpdatePriceByRate;
using ESISA.Core.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.RaisePriceByRate
{
    public class RaiseCorporateAdvertPriceByRateCommandRequest : IRequest<RaiseCorporateAdvertPriceByRateCommandResponse>
    {
        public Guid CorporateAdvertId { get; set; }
        public PriceChangeRateType RaiseRate { get; set; }

        public RaiseCorporateAdvertPriceByRateCommandRequest()
        {

        }

        public RaiseCorporateAdvertPriceByRateCommandRequest(Guid corporateAdvertId, PriceChangeRateType raiseRate)
        {
            CorporateAdvertId = corporateAdvertId;
            RaiseRate = raiseRate;
        }
    }
}
