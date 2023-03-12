using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Brands.DeleteRange
{
    public class DeleteRangeBrandCommandRequest : IRequest<DeleteRangeBrandCommandResponse>
    {
        public Guid[] BrandIds { get; set; }

        public DeleteRangeBrandCommandRequest()
        {

        }

        public DeleteRangeBrandCommandRequest(Guid[] brandIds)
        {
            BrandIds = brandIds;
        }
    }
}
