using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.CreateProductDemand
{
    public class CreateProductDemandCommandRequest : IRequest<CreateProductDemandCommandResponse>
    {
        public Guid CorporateDealerId { get; set; }
        public String SenderNote { get; set; }
        public Guid CategoryId { get; set; }
        public String ProductName { get; set; }

        public CreateProductDemandCommandRequest()
        {

        }

        public CreateProductDemandCommandRequest(Guid corporateDealerId, string senderNote, Guid categoryId, string productName)
        {
            CorporateDealerId = corporateDealerId;
            SenderNote = senderNote;
            CategoryId = categoryId;
            ProductName = productName;
        }
    }
}
