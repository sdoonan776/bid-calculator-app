using BidCalculatorApp.Helpers;

namespace tests.UnitTests.Helpers
{
    public class MoneyTest
    {
        [Fact]
        public void Round_ReturnsDecimalValueWithTwoDecimalPlaces()
        {
            var result = Money.Round(89.8768678m);
            Assert.Equal(89.88m, result);
        }
    }
}