using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.UpdatePrice;
using ESISA.Core.Domain.Constants;
using ESISA.Core.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.UpdatePriceByRate
{
    public class RaiseIndividualAdvertPriceByRateCommandRequest : IRequest<RaiseIndividualAdvertPriceByRateCommandResponse>
    {
        public Guid IndividualAdvertId { get; set; }
        public PriceChangeRateType RaiseRate { get; set; }

        public RaiseIndividualAdvertPriceByRateCommandRequest()
        {

        }

        public RaiseIndividualAdvertPriceByRateCommandRequest( Guid ındividualAdvertId, PriceChangeRateType raiseRate)
        {
            IndividualAdvertId = ındividualAdvertId;
            RaiseRate = raiseRate;
        }
    }
}
