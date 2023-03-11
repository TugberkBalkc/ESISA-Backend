using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Brands.Update
{

    public class UpdateBrandCommandRequest : IRequest<UpdateBrandCommandResponse>
    {
        public Guid BrandId { get; set; }
        public String BrandName { get; set; }
        public String BrandWebsiteUrl { get; set; }

        public UpdateBrandCommandRequest()
        {

        }

        public UpdateBrandCommandRequest(Guid brandId, string brandName, string brandWebsiteUrl)
        {
            BrandId = brandId;
            BrandName = brandName;
            BrandWebsiteUrl = brandWebsiteUrl;
        }
    }
}
