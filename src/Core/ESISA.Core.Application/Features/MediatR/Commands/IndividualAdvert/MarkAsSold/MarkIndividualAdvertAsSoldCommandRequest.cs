using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.ReducePriceByRate;
using ESISA.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.MarkAsSold
{
    public class MarkIndividualAdvertAsSoldCommandRequest : IRequest<MarkIndividualAdvertAsSoldCommandResponse>
    {
        public Guid IndividualAdvertId { get; set; }

        public MarkIndividualAdvertAsSoldCommandRequest()
        {

        }

        public MarkIndividualAdvertAsSoldCommandRequest(Guid ındividualAdvertId)
        {
            IndividualAdvertId = ındividualAdvertId;
        }
    }
}
