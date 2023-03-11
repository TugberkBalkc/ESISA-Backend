using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos
{
    public class CategoryDemandDto
    {
        public Guid CategoryDemandId { get; set; }
        public DateTime CategoryDemandCreatedDate { get; set; }
        public DateTime CategoryDemandModifiedDate { get; set; }
        public bool CategoryDemandIsActive { get; set; }
        public bool CategoryDemandIsDeleted { get; set; }

        public Guid CorporateDealerId { get; set; }
        public String SenderNote { get; set; }
        public String CategoryName { get; set; }
    }
}
