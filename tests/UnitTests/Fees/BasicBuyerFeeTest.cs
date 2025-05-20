using BidCalculatorApp.BidCalculator.Fees;
using BidCalculatorApp.BidCalculator.Domain;

namespace UnitTests.Fees
{
    public class BasicBuyerFeeTest
    {
        private readonly IFee _basicBuyerFee;
        public BasicBuyerFeeTest()
        {
            _basicBuyerFee = new BasicBuyerFee();
        }

        public static TheoryData<decimal, decimal> CommonVehicleData = new()
        {
            { 99.99m, 10m },
            { 100.10m, 10.01m },
            { 500.01m, 50m }
        };

        public static TheoryData<decimal, decimal> LuxuryVehicleData = new()
        {
            { 249.99m, 25m },
            { 250.10m, 25.01m },
            { 1000000m, 200m }
        };

        [Theory]
        [MemberData(nameof(CommonVehicleData))]
        public void Calculate_ReturnsExpectedDecimalValue_WhenVehicleTypeIsCommon(decimal price, decimal expected)
        {
            decimal result = _basicBuyerFee.Calculate(price, VehicleType.Common);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(LuxuryVehicleData))]
        public void Calculate_ReturnsExpectedDecimalValue_WhenVehicleTypeIsLuxury(decimal price, decimal expected)
        {
            decimal result = _basicBuyerFee.Calculate(price, VehicleType.Luxury);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_ThrowsArgumentOutOfRangeException_WhenVehicleTypeIsInvalid()
        {
            decimal price = 356m; 
            VehicleType invalidType = (VehicleType)999m;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                _basicBuyerFee.Calculate(price, invalidType)
            );
        }
    }
}