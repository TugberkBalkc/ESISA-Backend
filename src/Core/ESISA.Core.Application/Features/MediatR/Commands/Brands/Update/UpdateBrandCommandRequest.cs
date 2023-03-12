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
        public bool BrandIsActive { get; set; }
        public String BrandName { get; set; }
        public String BrandWebsiteUrl { get; set; }

        public UpdateBrandCommandRequest()
        {

        }

        public UpdateBrandCommandRequest(Guid brandId, bool brandIsActive, string brandName, string brandWebsiteUrl)
        {
            BrandId = brandId;
            BrandIsActive = brandIsActive;
            BrandName = brandName;
            BrandWebsiteUrl = brandWebsiteUrl;
        }
    }
}
