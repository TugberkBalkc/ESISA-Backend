using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Create;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.WholesaleAdverts.Create
{
    public class CreateWholesaleAdvertCommandRequest : IRequest<CreateWholesaleAdvertCommandResponse>
    {
        public String AdvertTitle { get; set; }
        public String AdvertDescription { get; set; }

        public Guid WholesaleAdvertCorporateDealerId { get; set; }
        public Guid WholesaleAdvertProductId { get; set; }

        public int WholesaleAdvertMinimumPurchaseAmount { get; set; }
        public int WholesaleAdvertMaximumPurchaseAmount { get; set; }
        public decimal WholesaleAdvertPricePerUnit { get; set; }
        public int WholesaleAdvertStockAmount { get; set; }

        public CreateWholesaleAdvertCommandRequest()
        {

        }

        public CreateWholesaleAdvertCommandRequest(string advertTitle, string advertDescription, Guid wholesaleAdvertCorporateDealerId, Guid wholesaleAdvertProductId, int wholesaleAdvertMinimumPurchaseAmount, int wholesaleAdvertMaximumPurchaseAmount, decimal wholesaleAdvertPricePerUnit, decimal wholesaleAdvertDiscountedPricePerUnit, int wholesaleAdvertStockAmount)
        {
            AdvertTitle = advertTitle;
            AdvertDescription = advertDescription;
            WholesaleAdvertCorporateDealerId = wholesaleAdvertCorporateDealerId;
            WholesaleAdvertProductId = wholesaleAdvertProductId;
            WholesaleAdvertMinimumPurchaseAmount = wholesaleAdvertMinimumPurchaseAmount;
            WholesaleAdvertMaximumPurchaseAmount = wholesaleAdvertMaximumPurchaseAmount;
            WholesaleAdvertPricePerUnit = wholesaleAdvertPricePerUnit;
            WholesaleAdvertStockAmount = wholesaleAdvertStockAmount;
        }
    }
}
