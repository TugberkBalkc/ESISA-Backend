using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Security
{
    public class HashResultDto
    {
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }

        public HashResultDto(byte[] hash, byte[] salt)
        {
            Hash = hash;
            Salt = salt;
        }
    }
}
