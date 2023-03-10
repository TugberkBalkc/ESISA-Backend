using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }
        public DateTime CategoryCreatedDate { get; set; }
        public DateTime CategoryModifiedDate { get; set; }
        public bool CategoryIsDeleted { get; set; }
        public bool CategoryIsActive { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public Guid ParentCategoryId { get; set; }
    }
}
