using BidCalculatorApp.BidCalculator.Application;
using BidCalculatorApp.BidCalculator.Fees;
using BidCalculatorApp.BidCalculator.Domain;
using Moq;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace UnitTests.Application
{
    public class BidCalculatorTest
    {
        private readonly IBidCalculator _bidCalculator;
        private readonly Mock<IFee>[] _feeMocks;
        public BidCalculatorTest()
        {
            _feeMocks = new[]
            {
                BuildFeeMock("basicBuyerFee", 39.80m, 180.00m),
                BuildFeeMock("sellerSpecialFee", 7.96m, 72.00m),
                BuildFeeMock("associationFee", 5.00m, 15.00m),
                BuildFeeMock("storageFee", 100.00m, 100.00m)
            };

            _bidCalculator = new BidCalculator(_feeMocks.Select(m => m.Object));
        }

        [Fact]
        public void CalculateTotal_ReturnsExpectedTotal_WhenVehicleTypeIsCommon()
        {
            BidCalculatorResponse result = _bidCalculator.CalculateTotal(398m, VehicleType.Common);

            Assert.Equal(550.76m, result.Total);

            foreach (var mock in _feeMocks)
            {
                mock.Verify(f => f.Calculate(398.00m, VehicleType.Common), Times.Once);
            }
        }

        [Fact]
        public void CalculateTotal_ReturnsExpectedFeeBreakdown_WhenVehicleTypeIsCommon()
        {
            BidCalculatorResponse result = _bidCalculator.CalculateTotal(398m, VehicleType.Common);

            var expectedFees = new Dictionary<string, decimal>
            {
                ["basicBuyerFee"] = 39.80m,
                ["sellerSpecialFee"] = 7.96m,
                ["associationFee"] = 5.00m,
                ["storageFee"] = 100.00m
            };

            Dictionary<string, decimal> actualFees = result.FeeItems;

            Assert.Equal(expectedFees, actualFees);

            foreach (var mock in _feeMocks)
            {
                mock.Verify(f => f.Calculate(398.00m, VehicleType.Common), Times.Once);
            }  
        }

        [Fact]
        public void CalculateTotal_ReturnsExpectedTotal_WhenVehicleTypeIsLuxury()
        {
            BidCalculatorResponse result = _bidCalculator.CalculateTotal(1800.00m, VehicleType.Luxury);

            Assert.Equal(2167.00m, result.Total);
            foreach (var mock in _feeMocks)
            {
                mock.Verify(f => f.Calculate(1800.00m, VehicleType.Luxury), Times.Once);
            }
        }

        [Fact]
        public void CalculateTotal_ReturnsExpectedFeeBreakdown_WhenVehicleTypeIsLuxury()
        {
            BidCalculatorResponse result = _bidCalculator.CalculateTotal(1800.00m, VehicleType.Luxury);

            var expectedFees = new Dictionary<string, decimal>
            {
                ["basicBuyerFee"] = 180.00m,
                ["sellerSpecialFee"] = 72.00m,
                ["associationFee"] = 15.00m,
                ["storageFee"] = 100.00m
            };

            var actualFees = result.FeeItems;

            Assert.Equal(expectedFees, actualFees);
            
            foreach (var mock in _feeMocks)
            {
                mock.Verify(f => f.Calculate(1800.00m, VehicleType.Luxury), Times.Once);
            }
        }

        [Fact]
        public void CalculateTotal_ThrowsException_WhenPriceIsInvalid()
        {
            decimal price = -1m; 
            VehicleType type = VehicleType.Common;

            Assert.Throws<Exception>(() =>
                _bidCalculator.CalculateTotal(price, type)
            );
        }
        
        [Fact]
        public void CalculateTotal_ThrowsException_WhenVehicleTypeIsInvalid()
        {
            decimal price = 389m; 
            VehicleType type = (VehicleType)999;

            Assert.Throws<Exception>(() =>
                _bidCalculator.CalculateTotal(price, type)
            );
        }

        private static Mock<IFee> BuildFeeMock(string feeName, decimal commonFee, decimal luxuryFee)
        {
            var mock = new Mock<IFee>();

            mock.SetupGet(f => f.FeeName).Returns(feeName);

            mock.Setup(f => f.Calculate(It.IsAny<decimal>(), It.Is<VehicleType>(t => t == VehicleType.Common)))
                .Returns(commonFee);

            mock.Setup(f => f.Calculate(It.IsAny<decimal>(), It.Is<VehicleType>(t => t == VehicleType.Luxury)))
                .Returns(luxuryFee);

            return mock; 
        }
    }
}