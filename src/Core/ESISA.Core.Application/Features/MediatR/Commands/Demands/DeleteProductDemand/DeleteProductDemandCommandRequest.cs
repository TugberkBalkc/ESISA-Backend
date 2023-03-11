using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteProductDemand
{
    public class DeleteProductDemandCommandRequest : IRequest<DeleteProductDemandCommandResponse>
    {
        public Guid ProductDemandId { get; set; }

        public DeleteProductDemandCommandRequest()
        {

        }

        public DeleteProductDemandCommandRequest(Guid productDemandId)
        {
            ProductDemandId = productDemandId;
        }
    }
}
