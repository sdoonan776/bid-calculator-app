using BidCalculatorApp.BidCalculator.Domain;
using BidCalculatorApp.BidCalculator.Fees;
using BidCalculatorApp.Helpers;
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

        public JsonObject CalculateTotal(decimal price, VehicleType type)
        {
            if (price < 0m)
                throw new Exception("Invalid Price, please enter a non negative number");

            if (!Enum.IsDefined(typeof(VehicleType), type))
                throw new Exception("Invalid Vehicle Type");

            JsonObject feesJson = new JsonObject();
            decimal feesTotal = 0m;

            foreach (IFee fee in _fees)
            {
                decimal value = fee.Calculate(price, type);
                feesJson.Add(fee.FeeName, value);
                feesTotal += value;
            }

            decimal total = Money.Round(feesTotal + price);    

            return new JsonObject
            {
                ["total"] = total,
                ["fees"] = feesJson
            };   
        }
    }
}