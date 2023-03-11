using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Brands.Delete
{
    public class DeleteBrandCommandRequest : IRequest<DeleteBrandCommandResponse>
    {
        public Guid BrandId { get; set; }

        public DeleteBrandCommandRequest(Guid brandId)
        {
            BrandId = brandId;
        }

        public DeleteBrandCommandRequest()
        {

        }
    }
}
