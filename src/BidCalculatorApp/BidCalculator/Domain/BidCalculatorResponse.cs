namespace BidCalculatorApp.BidCalculator.Domain
{
    public record BidCalculatorResponse
    {
        public decimal Total { get; init; }
        public Dictionary<string, decimal> FeeItems { get; init; } = [];
        
    }
}