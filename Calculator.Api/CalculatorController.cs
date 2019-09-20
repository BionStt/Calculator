using Calculator.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Api
{
    [Route("[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        public CalculatorController(ICalculatorService calculatorService)
        {
            CalculatorService = calculatorService;
        }

        private ICalculatorService CalculatorService { get; }

        [HttpGet]
        public string Get() => nameof(Ok);

        [HttpPost]
        public decimal Post(Calculation calculation)
        {
            return CalculatorService.Calculate(calculation);
        }
    }
}
