using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Options.Authentication
{
    public class RefreshTokenOptions
    {
        public int TokenLifeTimeInDays { get; set; }
        public int TokenTTL { get; set; }
    }
}
