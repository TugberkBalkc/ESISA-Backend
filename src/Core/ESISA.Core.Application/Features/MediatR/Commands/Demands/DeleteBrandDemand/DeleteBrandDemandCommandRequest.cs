using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteBrandDemand
{
    public class DeleteBrandDemandCommandRequest : IRequest<DeleteBrandDemandCommandResponse>
    {
        public Guid BrandDemandId { get; set; }

        public DeleteBrandDemandCommandRequest()
        {

        }

        public DeleteBrandDemandCommandRequest(Guid brandDemandId)
        {
            BrandDemandId = brandDemandId;
        }
    }
}
