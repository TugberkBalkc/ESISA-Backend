using ESISA.Core.Application.Dtos.Advert.Common;
using ESISA.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Advert.SwapAdvert
{
    public class SwapAdvertDto : AdvertDto
    {
        public bool IsSwapAdvertActive { get; set; }

        public Guid SwapAdvertId { get; set; }
        public Guid SwapAdvertIndividualDealerId { get; set; }
        public Guid SwapAdvertProductId { get; set; }
        public ProductConditionType SwapAdvertProductConditionType { get; set; }
    }
}
