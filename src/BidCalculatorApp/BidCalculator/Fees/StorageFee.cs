using BidCalculatorApp.BidCalculator.Domain;
using BidCalculatorApp.Helpers;

namespace BidCalculatorApp.BidCalculator.Fees
{
    public class StorageFee : IFee
    {
        public string FeeName => "storageFee";
        public decimal Calculate(decimal price, VehicleType type)
        {
            return Money.Round(100m);
        }
    }
}