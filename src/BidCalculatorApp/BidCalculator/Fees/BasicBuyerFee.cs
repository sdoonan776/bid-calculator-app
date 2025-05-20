using BidCalculatorApp.BidCalculator.Domain;
using BidCalculatorApp.Helpers;

namespace BidCalculatorApp.BidCalculator.Fees
{
    public class BasicBuyerFee : IFee
    {
        public string FeeName => "basicBuyerFee";
        public decimal Calculate(decimal price, VehicleType type)
        {
            decimal fee = (price * 10m) / 100m;

            decimal basicBuyerFee = type switch
            {
                VehicleType.Common => Math.Min(Math.Max(fee, 10m), 50m),
                VehicleType.Luxury => Math.Min(Math.Max(fee, 25m), 200m),
                _ => throw new ArgumentOutOfRangeException(
                    "Unsupported Vehicle Type"
                )
            };

            return Money.Round(basicBuyerFee);
        }
    }
}