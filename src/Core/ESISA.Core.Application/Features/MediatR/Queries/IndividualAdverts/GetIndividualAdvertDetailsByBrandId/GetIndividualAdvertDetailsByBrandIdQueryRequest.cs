using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetIndividualAdvertDetailsByBrandId
{
    public class GetIndividualAdvertDetailsByBrandIdQueryRequest : IRequest<GetIndividualAdvertDetailsByBrandQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public Guid BrandId { get; set; }

        public GetIndividualAdvertDetailsByBrandIdQueryRequest()
        {

        }

        public GetIndividualAdvertDetailsByBrandIdQueryRequest(int pageIndex, int pageSize, Guid brandId)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            BrandId = brandId;
        }
    }
}
