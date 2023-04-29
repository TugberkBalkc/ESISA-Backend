using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.MarkAsOutOfStock;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.UndoOutOfStock
{
    public class UndoCorporateAdvertOutOfStockCommandRequest : IRequest<UndoCorporateAdvertOutOfStockCommandResponse>
    {
        public Guid CorporateAdvertId { get; set; }
        public int StockAmount { get; set; }

        public UndoCorporateAdvertOutOfStockCommandRequest()
        {

        }

        public UndoCorporateAdvertOutOfStockCommandRequest(Guid corporateAdvertId, int stockAmount)
        {
            CorporateAdvertId = corporateAdvertId;
            StockAmount = stockAmount;
        }
    }
}
