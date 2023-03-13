using ESISA.Core.Application.Utilities.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Products.GetDetailsById
{
    public class GetDetailsByIdProductQueryRequest : IRequest<GetDetailsByIdProductQueryResponse>
    {
        public Guid ProductId { get; set; }

        public GetDetailsByIdProductQueryRequest()
        {

        }

        public GetDetailsByIdProductQueryRequest(Guid productId)
        {
            ProductId = productId;
        }
    }
}
