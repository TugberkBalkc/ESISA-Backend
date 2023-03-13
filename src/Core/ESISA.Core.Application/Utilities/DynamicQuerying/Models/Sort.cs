using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.DynamicQuerying.Models
{
    public class Sort
    {
        public string Field { get; set; }
        public string Direction { get; set; }

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
