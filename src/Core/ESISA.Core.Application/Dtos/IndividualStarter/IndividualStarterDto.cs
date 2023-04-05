using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.IndividualStarter
{
    public class IndividualStarterDto
    {
        public String StarterEmail { get; set; }
        public String StarterUserName { get; set; }
        public String StarterContactNumber { get; set; }
        public String StarterPassword { get; set; }

        public String StarterFirstName { get; set; }
        public String StarterLastName { get; set; }
        public String StarterNationalIdentity { get; set; }
        public DateTime StarterDateOfBirth { get; set; }

        public bool StarterStatus { get; set; }
    }
}
