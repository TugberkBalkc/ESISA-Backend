using ESISA.Core.Application.Features.MediatR.Commands.Products.Add;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Brands.Add
{
    public class AddBrandCommandRequest : IRequest<AddBrandCommandResponse>
    {
        public String BrandName { get; set; }
        public String BrandWebsiteUrl { get; set; }

        public AddBrandCommandRequest()
        {

        }

        public AddBrandCommandRequest(string brandName, string brandWebsiteUrl)
        {
            BrandName = brandName;
            BrandWebsiteUrl = brandWebsiteUrl;
        }
    }
}
