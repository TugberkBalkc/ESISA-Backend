using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Update;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.Update
{
    public class UpdateCorporateAdvertCommandRequest : IRequest<UpdateCorporateAdvertCommandResponse>
    {
        public Guid AdvertId { get; set; }
        public Guid CorporateAdvertId { get; set; }
        public String AdvertTitle { get; set; }
        public String AdvertDescription { get; set; }


        public decimal CorporateAdvertUnitPrice { get; set; }

        public int CorporateAdvertStockAmount { get; set; }

        public UpdateCorporateAdvertCommandRequest()
        {

        }

        public UpdateCorporateAdvertCommandRequest(Guid advertId, Guid corporateAdvertId, string advertTitle, string advertDescription, decimal corporateAdvertUnitPrice, int corporateAdvertStockAmount)
        {
            AdvertId = advertId;
            CorporateAdvertId = corporateAdvertId;
            AdvertTitle = advertTitle;
            AdvertDescription = advertDescription;
            CorporateAdvertUnitPrice = corporateAdvertUnitPrice;
            CorporateAdvertStockAmount = corporateAdvertStockAmount;
        }
    }
}
