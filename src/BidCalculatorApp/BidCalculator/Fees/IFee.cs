using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BidCalculatorApp.BidCalculator.Domain;

namespace BidCalculatorApp.BidCalculator.Fees
{
    public interface IFee
    {
        string FeeName { get; }
        public decimal Calculate(decimal price, VehicleType type);
    }
}