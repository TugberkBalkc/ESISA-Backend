using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Delete
{
    public class DeleteIndividualAdvertCommandRequest : IRequest<DeleteIndividualAdvertCommandResponse>
    {
        public Guid IndividualAdvertId { get; set; }

        public DeleteIndividualAdvertCommandRequest()
        {

        }

        public DeleteIndividualAdvertCommandRequest(Guid ındividualAdvertId)
        {
            IndividualAdvertId = ındividualAdvertId;
        }
    }
}
