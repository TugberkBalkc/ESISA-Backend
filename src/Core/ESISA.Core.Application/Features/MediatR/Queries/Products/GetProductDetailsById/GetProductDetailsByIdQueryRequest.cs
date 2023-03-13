using ESISA.Core.Application.Utilities.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Products.GetProductDetailsById
{
    public class GetProductDetailsByIdQueryRequest : IRequest<GetProductDetailsByIdQueryResponse>
    {
        public Guid ProductId { get; set; }

        public GetProductDetailsByIdQueryRequest()
        {

        }

        public GetProductDetailsByIdQueryRequest(Guid productId)
        {
            ProductId = productId;
        }
    }
}
