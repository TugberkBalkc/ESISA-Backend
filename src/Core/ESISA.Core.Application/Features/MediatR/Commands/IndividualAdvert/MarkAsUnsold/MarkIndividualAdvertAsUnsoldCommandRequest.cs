using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.MarkAsSold;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.MarkAsUnsold
{
    public class MarkIndividualAdvertAsUnsoldCommandRequest : IRequest<MarkIndividualAdvertAsUnsoldCommandResponse>
    {
        public Guid IndividualAdvertId { get; set; }

        public MarkIndividualAdvertAsUnsoldCommandRequest()
        {

        }

        public MarkIndividualAdvertAsUnsoldCommandRequest(Guid individualAdvertId)
        {
            IndividualAdvertId = individualAdvertId;
        }
    }
}
