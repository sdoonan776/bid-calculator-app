using BidCalculatorApp.BidCalculator.Fees;
using BidCalculatorApp.BidCalculator.Domain;

namespace UnitTests.Fees
{
    public class SellerSpecialFeeTest
    {
        private readonly IFee _sellerSpecialFee; 

        public SellerSpecialFeeTest()
        {
            _sellerSpecialFee = new SellerSpecialFee();
        }

        public static TheoryData<decimal, decimal> CommonVehicleData = new()
        {
            { 398m, 7.96m },
            { 501m, 10.02m },
            { 57m, 1.14m }
        };

        public static TheoryData<decimal, decimal> LuxuryVehicleData = new ()
        {
            { 1800m, 72m },
            { 1000000m, 40000m }
        }; 

        [Theory]
        [MemberData(nameof(CommonVehicleData))]
        public void Calculate_ReturnsExpectedDecimalValue_WhenVechileTypeIsCommon(decimal price, decimal expected)
        {
            decimal result = _sellerSpecialFee.Calculate(price, VehicleType.Common);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(LuxuryVehicleData))]
        public void Calculate_ReturnsExpectedDecimalValue_WhenVechileTypeIsLuxury(decimal price, decimal expected)
        {
            decimal result = _sellerSpecialFee.Calculate(price, VehicleType.Luxury);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_ThrowsArgumentOutOfRangeException_WhenVehicleTypeIsInvalid()
        {
            decimal price = 356m; 
            VehicleType invalidType = (VehicleType)999m;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                _sellerSpecialFee.Calculate(price, invalidType)
            );
        }
    }
}