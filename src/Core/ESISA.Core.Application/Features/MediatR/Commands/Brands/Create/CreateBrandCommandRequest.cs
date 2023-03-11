using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Brands.Create
{
    public class CreateBrandCommandRequest : IRequest<CreateBrandCommandResponse>
    {
        public String BrandName { get; set; }
        public String BrandWebsiteUrl { get; set; }

        public CreateBrandCommandRequest()
        {

        }

        public CreateBrandCommandRequest(string brandName, string brandWebsiteUrl)
        {
            BrandName = brandName;
            BrandWebsiteUrl = brandWebsiteUrl;
        }
    }
}
