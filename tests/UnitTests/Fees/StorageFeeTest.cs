using BidCalculatorApp.BidCalculator.Domain;
using BidCalculatorApp.BidCalculator.Fees;

namespace UnitTests.Fees
{

    public class StorageFeeTest
    {
        private readonly IFee _storageFee;

        public StorageFeeTest()
        {
            _storageFee = new StorageFee();
        }

        public static TheoryData<decimal, VehicleType> StorageFeeData = new ()
        {
            {398m, VehicleType.Common},
            {650m, VehicleType.Common},
            {1200m, VehicleType.Common},
            {1800m, VehicleType.Luxury},
            {3000m, VehicleType.Luxury},
            {1000000m, VehicleType.Luxury}
        };

        [Theory]
        [MemberData(nameof(StorageFeeData))]
        public void Calculate_ReturnsExpectedFlatDecimalValue_WithVariedPricesAndVehicleTypes(decimal price, VehicleType type)
        {
            decimal result = _storageFee.Calculate(price, type);

            Assert.Equal(100m, result); 
        }
    }
}