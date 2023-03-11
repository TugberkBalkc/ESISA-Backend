using ESISA.Core.Application.Constants.EntityConstantValues;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Categories.CreateMainCategory
{
    public class CreateMainCategoryCommandRequest : IRequest<CreateMainCategoryCommandResponse>
    {
        public String CategoryName { get; set; }
        public String CategoryDescription { get; set; }

        public CreateMainCategoryCommandRequest()
        {

        }

        public CreateMainCategoryCommandRequest(string categoryName, string categoryDescription)
        {
            CategoryName = categoryName;
            CategoryDescription = categoryDescription;
        }
    }
}
