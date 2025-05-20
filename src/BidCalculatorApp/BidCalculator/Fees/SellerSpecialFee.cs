using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BidCalculatorApp.BidCalculator.Domain;
using BidCalculatorApp.Helpers;

namespace BidCalculatorApp.BidCalculator.Fees
{
    public class SellerSpecialFee : IFee
    {
        public string FeeName => "sellerSpecialFee";
        public decimal Calculate(decimal price, VehicleType type)
        {
            int percentage = type switch
            {
                VehicleType.Common => 2,
                VehicleType.Luxury => 4,
                _ => throw new ArgumentOutOfRangeException(
                    "Unsupported Vehicle Type"
                )
            };

            decimal sellerSpecialFee = (percentage * price) / 100;
            return Money.Round(sellerSpecialFee);
        }

        
    }
}