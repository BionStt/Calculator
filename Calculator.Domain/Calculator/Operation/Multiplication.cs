using System.Linq;

namespace Calculator.Domain
{
    public class Multiplication : IOperation
    {
        public decimal Calculate(decimal[] numbers)
        {
            return numbers.Aggregate((result, number) => result * number);
        }
    }
}
