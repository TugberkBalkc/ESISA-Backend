using ESISA.Core.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Advert.CorporateAdverts
{
    public class NotDiscountedCorporateAdvertDto
    {
        public Guid AdvertId { get; set; }
        public Guid CorporateAdvertId { get; set; }

        public DateTime AdvertCreatedDate { get; set; }
        public DateTime AdvertModifiedDate { get; set; }
        public bool AdvertIsActive { get; set; }
        public bool AdvertIsDeleted { get; set; }

        public string AdvertTitle { get; set; }
        public string AdvertDescription { get; set; }

        public Guid CorporateAdvertCorporateDealerId { get; set; }
        public Guid CorporateAdvertProductId { get; set; }

        public int CorporateAdvertStockAmount { get; set; }
        public decimal CorporateAdvertUnitPrice { get; set; }
    }
}
