using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public DateTime ProductCreatedDate { get; set; }
        public DateTime ProductModifiedDate { get; set; }
        public bool ProductIsDeleted { get; set; }
        public bool ProductIsActive { get; set; }
        public string ProductName { get; set; }

        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }

        public ProductDto()
        {

        }

        public ProductDto
            (Guid productId, DateTime productCreatedDate,
             DateTime productModifiedDate, bool productIsDeleted,
             bool productIsActive, string productName,
             Guid categoryId, Guid brandId)
        {
            ProductId = productId;
            ProductCreatedDate = productCreatedDate;
            ProductModifiedDate = productModifiedDate;
            ProductIsDeleted = productIsDeleted;
            ProductIsActive = productIsActive;
            ProductName = productName;
            CategoryId = categoryId;
            BrandId = brandId;
        }
    }
}
