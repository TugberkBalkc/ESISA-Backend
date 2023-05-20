using ESISA.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.Common
{
    public static class PriceChangeUtility
    {
        public static decimal RaisePriceByRate(decimal price, decimal rate)
        {
            var updatedPrice = price + (price * Convert.ToInt32(rate) / 100);
            return updatedPrice;
        }

        public static decimal ReducePriceByRate(decimal price, decimal rate)
        {
            var updatedPrice = price - (price * Convert.ToInt32(rate) / 100);
            return updatedPrice;
        }
    }
}
