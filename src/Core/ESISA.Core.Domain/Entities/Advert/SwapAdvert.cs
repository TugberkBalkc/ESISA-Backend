using ESISA.Core.Domain.Entities.Common;
using ESISA.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class SwapAdvert : EntityBase
    {
        public Guid AdvertId { get; set; }
        public Guid IndividualDealerId { get; set; }
        public Guid ProductId { get; set; }

        public ProductConditionType ProductConditionType { get; set; }


        public virtual Advert Advert { get; set; }
        public virtual IndividualDealer IndividualDealer { get; set; }
        public virtual Product Product { get; set; }

        public virtual ICollection<SwapAdvertSwapableCategory> SwapAdvertSwapableCategories { get; set; }
        public virtual ICollection<SwapAdvertSwapableProduct> SwapAdvertSwapableProducts { get; set; }
    }
}
