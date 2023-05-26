using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Delete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.WholesaleAdverts.Delete
{
    public class DeleteWholesaleAdvertCommandRequest : IRequest<DeleteWholesaleAdvertCommandResponse>
    {
        public Guid WholesaleAdvertId { get; set; }

        public DeleteWholesaleAdvertCommandRequest()
        {

        }

        public DeleteWholesaleAdvertCommandRequest(Guid wholesaleAdvertId)
        {
            WholesaleAdvertId = wholesaleAdvertId;
        }
    }
}
