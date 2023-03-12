using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Products.DeleteRange
{
    public class DeleteRangeProductCommandRequest : IRequest<DeleteRangeProductCommandResponse>
    {
        public Guid[] ProductIds { get; set; }

        public DeleteRangeProductCommandRequest()
        {

        }

        public DeleteRangeProductCommandRequest(Guid[] productIds)
        {
            ProductIds = productIds;
        }
    }
}
