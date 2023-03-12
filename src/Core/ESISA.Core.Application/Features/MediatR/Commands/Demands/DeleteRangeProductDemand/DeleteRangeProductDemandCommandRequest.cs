using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteRangeProductDemand
{
    public class DeleteRangeProductDemandCommandRequest : IRequest<DeleteRangeProductDemandCommandResponse>
    {
        public Guid[] ProductDemandIds { get; set; }

        public DeleteRangeProductDemandCommandRequest()
        {

        }

        public DeleteRangeProductDemandCommandRequest(Guid[] productDemandIds)
        {
            ProductDemandIds = productDemandIds;
        }
    }
}
