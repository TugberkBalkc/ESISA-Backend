using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.UpdatePrice;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.UpdatePrice
{
    public class UpdateCorporateAdvertPriceCommandRequest : IRequest<UpdateCorporateAdvertPriceCommandResponse>
    {
        public Guid CorporateAdvertId { get; set; }

        public decimal UpdatedPrice { get; set; }

        public UpdateCorporateAdvertPriceCommandRequest()
        {

        }

        public UpdateCorporateAdvertPriceCommandRequest(Guid corporateAdvertId, decimal updatedPrice)
        {
            CorporateAdvertId = corporateAdvertId;
            UpdatedPrice = updatedPrice;
        }
    }
}
