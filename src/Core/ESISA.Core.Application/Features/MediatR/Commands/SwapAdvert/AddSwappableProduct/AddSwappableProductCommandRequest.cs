using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.AddSwappableProduct
{
    public class AddSwappableProductCommandRequest : IRequest<AddSwappableProductCommandResponse>
    {
        public Guid SwapAdvertId { get; set; }
        public Guid ProductId { get; set; }

        public AddSwappableProductCommandRequest()
        {

        }

        public AddSwappableProductCommandRequest(Guid swapAdvertId, Guid productId)
        {
            SwapAdvertId = swapAdvertId;
            ProductId = productId;
        }
    }
}
