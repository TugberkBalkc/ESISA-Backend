using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos
{
    public class ProductDemandDto
    {
        public Guid ProductDemandId { get; set; }
        public DateTime ProductDemandCreatedDate { get; set; }
        public DateTime ProductDemandModifiedDate { get; set; }
        public bool ProductDemandIsActive { get; set; }
        public bool ProductDemandIsDeleted { get; set; }

        public Guid CorporateDealerId { get; set; }
        public String SenderNote { get; set; }
        public Guid CategoryId { get; set; }
        public String ProductName { get; set; }
    }
}
