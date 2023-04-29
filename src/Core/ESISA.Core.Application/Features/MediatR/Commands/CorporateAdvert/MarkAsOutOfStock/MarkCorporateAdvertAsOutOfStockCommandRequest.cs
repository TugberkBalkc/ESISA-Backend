using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.MarkAsSold;
using ESISA.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.MarkAsOutOfStock
{
    public class MarkCorporateAdvertAsOutOfStockCommandRequest : IRequest<MarkCorporateAdvertAsOutOfStockCommandResponse>
    {
        public Guid CorporateAdvertId { get; set; }

        public MarkCorporateAdvertAsOutOfStockCommandRequest()
        {

        }

        public MarkCorporateAdvertAsOutOfStockCommandRequest(Guid corporateAdvertId)
        {
            CorporateAdvertId = corporateAdvertId;
        }
    }
}
