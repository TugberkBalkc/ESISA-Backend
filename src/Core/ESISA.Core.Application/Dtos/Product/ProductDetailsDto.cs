using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Product
{
    public class ProductDetailsDto
    {
        public Guid ProductId { get; set; }
        public DateTime ProductCreatedDate { get; set; }
        public DateTime ProductModifiedDate { get; set; }
        public bool ProductIsDeleted { get; set; }
        public bool ProductIsActive { get; set; }
        public string ProductName { get; set; }

        public Guid CategoryId { get; set; }
        public String CategoryName { get; set; }

        public Guid BrandId { get; set; }
        public String BrandName { get; set; }
    }
}
