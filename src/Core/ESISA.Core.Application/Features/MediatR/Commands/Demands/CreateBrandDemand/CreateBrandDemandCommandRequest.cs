using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.CreateBrandDemand
{
    public class CreateBrandDemandCommandRequest : IRequest<CreateBrandDemandCommandResponse>
    {
        public Guid CorporateDealerId { get; set; }
        public String SenderNote { get; set; }
        public String BrandName { get; set; }

        public CreateBrandDemandCommandRequest()
        {

        }

        public CreateBrandDemandCommandRequest(Guid corporateDealerId, string senderNote, string brandName)
        {
            CorporateDealerId = corporateDealerId;
            SenderNote = senderNote;
            BrandName = brandName;
        }
    }
}
