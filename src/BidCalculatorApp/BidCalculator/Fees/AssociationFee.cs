using BidCalculatorApp.BidCalculator.Domain;
using BidCalculatorApp.Helpers;

namespace BidCalculatorApp.BidCalculator.Fees
{
    public class AssociationFee : IFee
    {
        public string FeeName => "associationFee";
        public decimal Calculate(decimal price, VehicleType type) 
        {
            decimal associationFee = price switch 
            {
                < 1m => 0m,
                <= 500m => 5m,
                <= 1000m => 10m,
                <= 3000m => 15m,
                _ => 20m
            };
            return Money.Round(associationFee);
        }
    }
}