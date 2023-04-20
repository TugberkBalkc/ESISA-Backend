using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.UpdatePriceByRate;
using ESISA.Core.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.ReducePriceByRate
{
    public class ReduceIndividualAdvertPriceByRateCommandRequest : IRequest<ReduceIndividualAdvertPriceByRateCommandResponse>
    {
        public Guid IndividualAdvertId { get; set; }
        public PriceChangeRateType ReduceRate { get; set; }

        public ReduceIndividualAdvertPriceByRateCommandRequest()
        {

        }

        public ReduceIndividualAdvertPriceByRateCommandRequest(Guid ındividualAdvertId, PriceChangeRateType reduceRate)
        {
            IndividualAdvertId = ındividualAdvertId;
            ReduceRate = reduceRate;
        }
    }
}
