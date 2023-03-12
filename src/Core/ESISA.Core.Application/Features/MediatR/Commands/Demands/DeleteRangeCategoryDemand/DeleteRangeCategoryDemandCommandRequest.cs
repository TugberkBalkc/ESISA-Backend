using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteRangeCategoryDemand
{
    public class DeleteRangeCategoryDemandCommandRequest : IRequest<DeleteRangeCategoryDemandCommandResponse>
    {
        public Guid[] CategoryDemandIds { get; set; }

        public DeleteRangeCategoryDemandCommandRequest()
        {

        }

        public DeleteRangeCategoryDemandCommandRequest(Guid[] categoryDemandIds)
        {
            CategoryDemandIds = categoryDemandIds;
        }
    }
}
