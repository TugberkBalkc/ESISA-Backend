using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteRangeBrandDemand
{
    public class DeleteRangeBrandDemandCommandRequest : IRequest<DeleteRangeBrandDemandCommandResponse>
    {
        public Guid[] BrandDemandIds { get; set; }

        public DeleteRangeBrandDemandCommandRequest()
        {

        }

        public DeleteRangeBrandDemandCommandRequest(Guid[] brandDemandIds)
        {
            BrandDemandIds = brandDemandIds;
        }
    }
}
