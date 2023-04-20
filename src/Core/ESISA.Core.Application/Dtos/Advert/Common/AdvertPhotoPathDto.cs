using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Advert.Common
{
    public class AdvertPhotoPathDto
    {
        public Guid AdvertPhotoPathId { get; set; }
        public DateTime AdvertPhotoPathCreatedDate { get; set; }
        public DateTime AdvertPhotoPathModifiedDate { get; set; }
        public bool AdvertPhotoPathIsActive { get; set; }
        public bool AdvertPhotoPathIsDeleted { get; set; }
        public Guid AdvertId { get; set; }
        public String AdvertPhotoUrl { get; set; }

        public AdvertPhotoPathDto()
        {

        }

        public AdvertPhotoPathDto(Guid advertPhotoPathId, DateTime advertPhotoPathCreatedDate, DateTime advertPhotoPathModifiedDate, bool advertPhotoPathIsActive, bool advertPhotoPathIsDeleted, Guid advertId, string advertPhotoUrl)
        {
            AdvertPhotoPathId = advertPhotoPathId;
            AdvertPhotoPathCreatedDate = advertPhotoPathCreatedDate;
            AdvertPhotoPathModifiedDate = advertPhotoPathModifiedDate;
            AdvertPhotoPathIsActive = advertPhotoPathIsActive;
            AdvertPhotoPathIsDeleted = advertPhotoPathIsDeleted;
            AdvertId = advertId;
            AdvertPhotoUrl = advertPhotoUrl;
        }
    }
}
