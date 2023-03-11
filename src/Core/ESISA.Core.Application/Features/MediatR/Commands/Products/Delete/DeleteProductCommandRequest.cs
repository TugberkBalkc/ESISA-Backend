using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Products.Delete
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandRespone>
    {
        public Guid ProductId { get; set; }

        public DeleteProductCommandRequest()
        {

        }

        public DeleteProductCommandRequest(Guid productId)
        {
            ProductId = productId;
        }
    }
}
