using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteCategoryDemand
{
    public class DeleteCategoryDemandCommandRequest : IRequest<DeleteCategoryDemandCommandResponse>
    {
        public Guid CategoryDemandId { get; set; }

        public DeleteCategoryDemandCommandRequest()
        {

        }

        public DeleteCategoryDemandCommandRequest(Guid categoryDemandId)
        {
            CategoryDemandId = categoryDemandId;
        }
    }
}
