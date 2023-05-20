using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class Person : EntityBase
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String NationalIdentity { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}


