using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.ReducePriceByRate;
using ESISA.Core.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.ReducePriceByRate
{
    public class ReduceCorporateAdvertPriceByRateCommandRequest : IRequest<ReduceCorporateAdvertPriceByRateCommandResponse>
    {
        public Guid CorporateAdvertId { get; set; }
        public PriceChangeRateType ReduceRate { get; set; }

        public ReduceCorporateAdvertPriceByRateCommandRequest()
        {

        }

        public ReduceCorporateAdvertPriceByRateCommandRequest(Guid corporateAdvertId, PriceChangeRateType reduceRate)
        {
            CorporateAdvertId = corporateAdvertId;
            ReduceRate = reduceRate;
        }
    }
}
