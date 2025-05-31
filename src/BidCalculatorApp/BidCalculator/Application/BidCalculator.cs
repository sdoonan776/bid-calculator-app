using BidCalculatorApp.BidCalculator.Domain;
using BidCalculatorApp.BidCalculator.Fees;
using BidCalculatorApp.Helpers;
using Microsoft.VisualBasic;
using System.Text.Json.Nodes;

namespace BidCalculatorApp.BidCalculator.Application
{
    public class BidCalculator : IBidCalculator
    {
        private readonly IEnumerable<IFee> _fees;
        public BidCalculator(IEnumerable<IFee> fees)
        {
            _fees = fees;
        }

        public BidCalculatorResponse CalculateTotal(decimal price, VehicleType type)
        {
            if (price < 0m)
                throw new Exception("Invalid Price, please enter a non negative number");

            if (!Enum.IsDefined(typeof(VehicleType), type))
                throw new Exception("Invalid Vehicle Type");

            Dictionary<string, decimal> feeItems = new Dictionary<string, decimal>();
            decimal feesTotal = 0m;

            foreach (IFee fee in _fees)
            {
                try
                {
                    decimal value = fee.Calculate(price, type);
                    feeItems.Add(fee.FeeName, value);
                    feesTotal += value;
                } catch (Exception error) {
                    Console.WriteLine("Exception: " + error.Message);
                    throw; 
                }
            }

            decimal total = Money.Round(feesTotal + price);

            return new BidCalculatorResponse
            {
                Total = total,
                FeeItems = feeItems
            };
        }
    }
}