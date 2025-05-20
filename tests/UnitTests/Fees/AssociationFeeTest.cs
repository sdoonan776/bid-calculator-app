using BidCalculatorApp.BidCalculator.Fees;
using BidCalculatorApp.BidCalculator.Domain;
namespace UnitTests.Fees
{
    public class AssociationFeeTest
    {
        private readonly IFee _associationFee;

        public AssociationFeeTest()
        {
            _associationFee = new AssociationFee();
        }

        public static TheoryData<decimal, decimal> AssociationFeeData() => new()
        {
            { -1m, 0m },
            { 0m, 0m },
            { 1m, 5m },
            { 500m, 5m },
            { 1000m, 10m },
            { 3000m, 15m },
            { 5000m, 20m },
            { 32000000m, 20m }
        };

        [Theory]
        [MemberData(nameof(AssociationFeeData))]
        public void Calculate_ReturnsExpectedDecimalValue(decimal price, decimal expected)
        {
            decimal result = _associationFee.Calculate(price, VehicleType.Common);

            Assert.Equal(expected, result);
        }
    }
}