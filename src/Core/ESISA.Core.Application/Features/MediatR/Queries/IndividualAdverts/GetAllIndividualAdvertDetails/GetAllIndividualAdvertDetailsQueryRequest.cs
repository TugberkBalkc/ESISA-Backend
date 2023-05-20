using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetAllIndividualAdvertDetails
{
    public class GetAllIndividualAdvertDetailsQueryRequest : IRequest<GetAllIndividualAdvertDetailsQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetAllIndividualAdvertDetailsQueryRequest()
        {

        }

        public GetAllIndividualAdvertDetailsQueryRequest(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
