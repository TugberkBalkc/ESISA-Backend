using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.DynamicQuerying
{
    public class Sort
    {
        public String Field { get; set; }
        public String Direction { get; set; }

        public Sort()
        {

        }

        public Sort(string field, string direction)
        {
            Field = field;
            Direction = direction;
        }
    }
}
