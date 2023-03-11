using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.CreateCategoryDemand
{
    public class CreateCategoryDemandCommandRequest : IRequest<CreateCategoryDemandCommandResponse>
    {
        public Guid CorporateDealerId { get; set; }
        public String SenderNote { get; set; }
        public String CategoryName { get; set; }

        public CreateCategoryDemandCommandRequest()
        {

        }

        public CreateCategoryDemandCommandRequest(Guid corporateDealerId, string senderNote, string categoryName)
        {
            CorporateDealerId = corporateDealerId;
            SenderNote = senderNote;
            CategoryName = categoryName;
        }
    }
}
