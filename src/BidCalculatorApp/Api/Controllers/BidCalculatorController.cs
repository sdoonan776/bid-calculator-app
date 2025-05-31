using System.Text.Json;
using System.Text.Json.Nodes;
using BidCalculatorApp.BidCalculator.Application;
using BidCalculatorApp.BidCalculator.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculatorApp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BidCalculatorController : ControllerBase
    {
        private readonly IBidCalculator _bidCalculator;

        public BidCalculatorController(IBidCalculator bidCalculator)
        {
            _bidCalculator = bidCalculator;    
        }

        [HttpGet("calculate")]
        public IActionResult Get(decimal price, string type)
        {
            VehicleType vehicleType = Enum.Parse<VehicleType>(type, true);
            BidCalculatorResponse total = _bidCalculator.CalculateTotal(price, vehicleType);
            return Ok(total);
        }
        
    }
}