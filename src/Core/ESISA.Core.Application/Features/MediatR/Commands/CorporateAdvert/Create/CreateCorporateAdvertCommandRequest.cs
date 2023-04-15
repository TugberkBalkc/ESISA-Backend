using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
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

        public int CorporateAdvertStockAmount { get; set; }
        public decimal CorporateAdvertUnitPrice { get; set; }
    }
}
