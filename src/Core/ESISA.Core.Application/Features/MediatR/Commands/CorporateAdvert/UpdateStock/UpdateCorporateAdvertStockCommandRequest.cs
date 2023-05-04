using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.UpdatePrice;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.UpdateStock
{
    public class UpdateCorporateAdvertStockCommandRequest : IRequest<UpdateCorporateAdvertStockCommandResponse>
    {
        public Guid CorporateAdvertId { get; set; }
        public int UpdatedStockAmount { get; set; }

        public UpdateCorporateAdvertStockCommandRequest()
        {

        }

        public UpdateCorporateAdvertStockCommandRequest(Guid corporateAdvertId, int updatedStockAmount)
        {
            CorporateAdvertId = corporateAdvertId;
            UpdatedStockAmount = updatedStockAmount;
        }
    }
}
