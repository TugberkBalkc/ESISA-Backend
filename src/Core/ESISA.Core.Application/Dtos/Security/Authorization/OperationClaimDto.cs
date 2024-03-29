﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Security.Authorization
{
    public class OperationClaimDto
    {
        public Guid OperationClaimId { get; set; }
        public DateTime OperationClaimCreatedDate { get; set; }
        public DateTime OperationClaimModifiedDate { get; set; }
        public bool OperationClaimIsDeleted { get; set; }
        public bool OperationClaimIsActive { get; set; }
        public String OperationClaimName { get; set; }
    }
}
