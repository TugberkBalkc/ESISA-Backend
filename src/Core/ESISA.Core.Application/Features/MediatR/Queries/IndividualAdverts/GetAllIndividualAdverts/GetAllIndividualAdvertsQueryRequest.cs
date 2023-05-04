using ESISA.Core.Application.Constants.Request;
using ESISA.Core.Application.Dtos.Product;
using ESISA.Core.Application.Features.MediatR.Queries.Products.GetAllProducts;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetAllIndividualAdverts
{
    public class GetAllIndividualAdvertsQueryRequest : IRequest<GetAllIndividualAdvertsQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; } = QueryRequestConstants.DefaultPageIndex;
        public int PageSize { get; set; } = QueryRequestConstants.DefaultPageSize;

        public GetAllIndividualAdvertsQueryRequest()
        {

        }

        public GetAllIndividualAdvertsQueryRequest(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
