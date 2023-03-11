using ESISA.Core.Application.Features.MediatR.Commands.Categories.UpdateMainCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Categories.UpdateMainCategory
{
    public class UpdateMainCategoryCommandRequest : IRequest<UpdateMainCategoryCommandResponse>
    {
        public Guid CategoryId { get; set; }
        public String CategoryName { get; set; }
        public String CategoryDescription { get; set; }

        public UpdateMainCategoryCommandRequest()
        {

        }

        public UpdateMainCategoryCommandRequest(Guid categoryId, string categoryName, string categoryDescription)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            CategoryDescription = categoryDescription;
        }
    }
}

   
