using ESISA.Core.Application.Dtos.Advert.IndividualAdvert;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.CorporateAdverts.GetAllCorporateAdverts
{
    public class GetAllCorporateAdvertsQueryRequest : IRequest<GetAllCorporateAdvertsQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetAllCorporateAdvertsQueryRequest()
        {

        }

        public GetAllCorporateAdvertsQueryRequest(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
