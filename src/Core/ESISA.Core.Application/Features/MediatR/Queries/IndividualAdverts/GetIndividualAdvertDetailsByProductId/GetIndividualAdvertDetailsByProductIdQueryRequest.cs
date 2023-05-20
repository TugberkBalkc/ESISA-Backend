using ESISA.Core.Application.Features.MediatR.Requests.Common;
using FluentValidation.Internal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetIndividualAdvertDetailsByProductId
{
    public class GetIndividualAdvertDetailsByProductIdQueryRequest : IRequest<GetIndividualAdvertDetailsByProductIdQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public Guid ProductId { get; set; }

        public GetIndividualAdvertDetailsByProductIdQueryRequest()
        {

        }

        public GetIndividualAdvertDetailsByProductIdQueryRequest(int pageIndex, int pageSize, Guid productId)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            ProductId = productId;
        }
    }
}
