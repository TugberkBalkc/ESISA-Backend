using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.User
{
    public class IndividualStarterDto
    {
        public Guid StarterUserId { get; set; }
        public Guid StarterCustomerId { get; set; }
        public Guid StarterDealerId { get; set; }
        public Guid StarterIndividualCustomerId { get; set; }
        public Guid StarterIndividualDealerId { get; set; }

        public DateTime StarterUserCreatedDate { get; set; }
        public DateTime StarterUserModifiedDate { get; set; }
        public bool StarterUserIsActive { get; set; }
        public bool StarterUserIsDeleted { get; set; }

        public string StarterUserEmail { get; set; }
        public string StarterUserName { get; set; }
        public string StarterUserContactNumber { get; set; }
        public string StarterUserPassword { get; set; }

        public string StarterFirstName { get; set; }
        public string StarterLastName { get; set; }
        public string StarterNationalIdentity { get; set; }
        public DateTime StarterDateOfBirth { get; set; }

        public bool StarterStatus { get; set; }
    }
}
