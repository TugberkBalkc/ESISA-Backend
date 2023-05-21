using ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetIndividualAdvertDetailsByCategoryId;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetIndividualAdvertDetailsByDealerId
{
    public class GetIndividualAdvertDetailsByDealerIdQueryRequest : IRequest<GetIndividualAdvertDetailsByDealerIdQueryResponse>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public Guid IndividualDealerId { get; set; }

        public GetIndividualAdvertDetailsByDealerIdQueryRequest()
        {

        }

        public GetIndividualAdvertDetailsByDealerIdQueryRequest(int pageIndex, int pageSize, Guid individualDealerId)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            IndividualDealerId = individualDealerId;
        }
    }
}
