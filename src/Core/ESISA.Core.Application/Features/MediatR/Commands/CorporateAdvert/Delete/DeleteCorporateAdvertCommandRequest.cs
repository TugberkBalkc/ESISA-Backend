using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.Delete
{
    public class DeleteCorporateAdvertCommandRequest : IRequest<DeleteCorporateAdvertCommandResponse>
    {
        public Guid CorporateAdvertId { get; set; }

        public DeleteCorporateAdvertCommandRequest()
        {

        }

        public DeleteCorporateAdvertCommandRequest(Guid corporateAdvertId)
        {
            CorporateAdvertId = corporateAdvertId;
        }
    }
}
