
using System.Text.Json.Nodes;
using BidCalculatorApp.BidCalculator.Domain;

namespace BidCalculatorApp.BidCalculator.Application
{
    public interface IBidCalculator
    {
        public BidCalculatorResponse CalculateTotal(decimal price, VehicleType type);
    }
}