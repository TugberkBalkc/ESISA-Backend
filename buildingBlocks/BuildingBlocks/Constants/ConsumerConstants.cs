using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Constants
{
    public static class ConsumerConstants
    {
        public static String AlignConsumerLog(String consumerName,String consumedObjectName, String operationType) 
        {
            return $"<<{consumedObjectName} was consumed by {consumerName} with operation {operationType} at {DateTime.Now.ToString()}>>";
        } 
    }
}
