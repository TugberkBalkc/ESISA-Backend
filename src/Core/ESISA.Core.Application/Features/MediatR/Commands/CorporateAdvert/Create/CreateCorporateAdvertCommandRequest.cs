using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Create;
using ESISA.Core.Domain.Constants;
using ESISA.Core.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.Create
{
    public class CreateCorporateAdvertCommandRequest : IRequest<CreateCorporateAdvertCommandResponse> 
    {
        public String AdvertTitle { get; set; }
        public String AdvertDescription { get; set; }

        public Guid CorporateAdvertCorporateDealerId { get; set; }
        public Guid CorporateAdvertProductId { get; set; }

        public decimal CorporateAdvertUnitPrice { get; set; }
    
        public int CorporateAdvertStockAmount { get; set; }

        public CreateCorporateAdvertCommandRequest()
        {

        }

        public CreateCorporateAdvertCommandRequest(string advertTitle, string advertDescription, Guid corporateAdvertCorporateDealerId, Guid corporateAdvertProductId, decimal corporateAdvertUnitPrice, int corporateAdvertStockAmount)
        {
            AdvertTitle = advertTitle;
            AdvertDescription = advertDescription;
            CorporateAdvertCorporateDealerId = corporateAdvertCorporateDealerId;
            CorporateAdvertProductId = corporateAdvertProductId;
            CorporateAdvertUnitPrice = corporateAdvertUnitPrice;
            CorporateAdvertStockAmount = corporateAdvertStockAmount;
        }
    }
}
