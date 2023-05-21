using ESISA.Core.Application.Features.MediatR.Queries.CorporateAdverts.GetAllCorporateAdvertDetails;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.CorporateAdverts.GetCorporateAdvertDetailsByBrandId
{
    public class GetCorporateAdvertDetailsByBrandIdQueryRequest : IRequest<GetCorporateAdvertDetailsByBrandIdQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public Guid BrandId { get; set; }

        public GetCorporateAdvertDetailsByBrandIdQueryRequest()
        {

        }

        public GetCorporateAdvertDetailsByBrandIdQueryRequest(int pageIndex, int pageSize, Guid brandId)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            BrandId = brandId;
        }
    }
}
