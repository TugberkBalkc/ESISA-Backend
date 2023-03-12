using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Categories.Update
{
    public class UpdateSubCategoryCommandRequest : IRequest<UpdateSubCategoryCommandResponse>
    {
        public Guid CategoryId { get; set; }
        public bool CategoryIsActive  { get; set; }
        public Guid ParentCategoryId { get; set; }
        public String CategoryName { get; set; }
        public String CategoryDescription { get; set; }

        public UpdateSubCategoryCommandRequest()
        {

        }

        public UpdateSubCategoryCommandRequest(Guid categoryId, bool categoryIsActive, Guid parentCategoryId, string categoryName, string categoryDescription)
        {
            CategoryId = categoryId;
            CategoryIsActive = categoryIsActive;
            ParentCategoryId = parentCategoryId;
            CategoryName = categoryName;
            CategoryDescription = categoryDescription;
        }
    }
}
