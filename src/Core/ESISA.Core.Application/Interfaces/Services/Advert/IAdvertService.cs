using ESISA.Core.Application.Dtos.Advert.IndividualAdvert;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Interfaces.Services.Advert
{
    public interface IAdvertService
    {
        void SetIndividualAdvertAdvertDetails(IQueryable<IndividualAdvert> individualAdverts, IList<IndividualAdvertDetailsDto> individualAdvertDetailsDtos);

        void SetIndividualAdvertDealerDetails(IQueryable<IndividualAdvert> individualAdverts, IList<IndividualAdvertDetailsDto> individualAdvertDetailsDtos);

        void SetIndividualAdvertCategoryDetails(IQueryable<IndividualAdvert> individualAdverts);
    }
}
