using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Categories.DeleteRange
{
    public class DeleteRangeCategoryCommandRequest : IRequest<DeleteRangeCategoryCommandResponse>
    {
        public Guid[] CategoryIds { get; set; }

        public DeleteRangeCategoryCommandRequest()
        {

        }

        public DeleteRangeCategoryCommandRequest(Guid[] categoryIds)
        {
            CategoryIds = categoryIds;
        }
    }
}
