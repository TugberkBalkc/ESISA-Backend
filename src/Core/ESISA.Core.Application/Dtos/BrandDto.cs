using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos
{
    public class BrandDto
    {
        public Guid BrandId { get; set; }
        public DateTime BrandCreatedDate { get; set; }
        public DateTime BrandModifiedDate { get; set; }
        public bool BrandIsDeleted { get; set; }
        public bool BrandIsActive { get; set; }
        public string BrandName { get; set; }
        public string BrandWebsiteUrl { get; set; }
    }
}
