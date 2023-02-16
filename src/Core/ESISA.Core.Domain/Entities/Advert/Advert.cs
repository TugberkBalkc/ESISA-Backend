using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class Advert : EntityBase
    {
        public String Title { get; set; }
        public String Description { get; set; }


        public virtual CorporateAdvert CorporateAdvert { get; set; }
        public virtual IndividualAdvert IndividualAdvert { get; set; }
        public virtual SwapAdvert SwapAdvert { get; set; }
        public virtual WholesaleAdvert WholesaleAdvert { get; set; }
        public virtual ICollection<AdvertPhotoPath> AdvertPhotoPaths { get; set; }
    }
}
