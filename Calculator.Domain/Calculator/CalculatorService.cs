namespace Calculator.Domain
{
    public class CalculatorService : ICalculatorService
    {
        public decimal Calculate(Calculation calculation)
        {
            var operation = Factory.Get<IOperation>(calculation.Operation.ToString());

            if (operation == null) { return 0; }

            return operation.Calculate(calculation.Numbers);
        }
    }
}
