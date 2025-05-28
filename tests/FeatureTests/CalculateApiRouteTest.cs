using System.Text.Json;
using System.Net;
using Program = BidCalculatorApp.Program; 

namespace tests.FeatureTests
{
    public class CalculateApiRouteTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ApiRoutesTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        public static TheoryData<decimal, string, decimal, decimal, decimal, decimal, decimal> ApiRouteData = new()
        {
            {389m, "Common", 550.76m, 38.98m, 7.96m, 10.00m, 100.00m},
            {1800m, "Luxury", 2167.00m, 180.00m, 72.00m, 15.00m, 100.00m},
        };

        public static TheoryData<decimal, string> BadResponseData = new()
        {
            {-1m, "Common"},
            {200m, "InvalidType"},
            {0m, null}
        };

        [Fact]
        public async Task Get_Returns200StatusCodeAndContentTypeHeaders()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("api/v1/bidcalculator/calculate?price=389&type=Common");

            response.EnsureSuccessStatusCode();

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType!.ToString());
        }

        [Theory]
        [MemberData(nameof(ApiRouteData))]
        public async Task Get_ReturnsExpectedJsonResponse(
            decimal price,
            string type,
            decimal expectedTotal,
            decimal basicBuyerFee,
            decimal sellerSpecialFee,
            decimal associationFee,
            decimal storageFee
        )
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync($"api/v1/bidcalculator/calculate?price={price}&type={type}");

            var root = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
            var fees = root.GetProperty("fees");

            Assert.Equal(expectedTotal, root.GetProperty("total").GetDecimal());
            Assert.Equal(basicBuyerFee, fees.GetProperty("basicBuyerFee").GetDecimal());
            Assert.Equal(sellerSpecialFee, fees.GetProperty("sellerSpecialFee").GetDecimal());
            Assert.Equal(associationFee, fees.GetProperty("associationFee").GetDecimal());
            Assert.Equal(storageFee, fees.GetProperty("storageFee").GetDecimal());
        }

        [Theory]
        [MemberData(nameof(BadResponseData))]
        public async Task Get_ReturnsBadResponse_WithInvalidParameters(decimal price, string type)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync($"api/v1/bidcalculator/calculate?price={price}&type={type}");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}