using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.User
{
    public class IndividualStarterDto
    {
        public Guid StarterId { get; set; }
        public DateTime StarterCreatedDate { get; set; }
        public DateTime StarterModifiedDate { get; set; }
        public bool StarterIsActive { get; set; }
        public bool StarterIsDeleted { get; set; }

        public string StarterEmail { get; set; }
        public string StarterUserName { get; set; }
        public string StarterContactNumber { get; set; }
        public string StarterPassword { get; set; }

        public string StarterFirstName { get; set; }
        public string StarterLastName { get; set; }
        public string StarterNationalIdentity { get; set; }
        public DateTime StarterDateOfBirth { get; set; }

        public bool StarterStatus { get; set; }
    }
}
