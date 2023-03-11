﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos
{
    public class BrandDemandDto
    {
        public Guid BrandDemandId { get; set; }
        public DateTime BrandDemandCreatedDate { get; set; }
        public DateTime BrandDemandModifiedDate { get; set; }
        public bool BrandDemandIsActive { get; set; }
        public bool BrandDemandIsDeleted { get; set; }

        public Guid CorporateDealerId { get; set; }
        public String SenderNote { get; set; }
        public String BrandName { get; set; }
    }
}
