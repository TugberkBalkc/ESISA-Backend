using ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetAllIndividualAdvertDetails;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.DynamicQuerying.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetIndividualAdvertDetailsByDynamic
{
    public class GetIndividualAdvertDetailsByDynamicQueryRequest : IRequest<GetIndividualAdvertDetailsByDynamicQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public DynamicQuery DynamicQuery { get; set; }

        public GetIndividualAdvertDetailsByDynamicQueryRequest()
        {

        }

        public GetIndividualAdvertDetailsByDynamicQueryRequest(int pageIndex, int pageSize, DynamicQuery dynamicQuery)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            DynamicQuery = dynamicQuery;
        }
    }
}
