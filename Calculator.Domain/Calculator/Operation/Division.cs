using System.Linq;

namespace Calculator.Domain
{
    public class Division : IOperation
    {
        public decimal Calculate(decimal[] numbers)
        {
            if (numbers.Any(x => x == 0)) { return 0; }

            return numbers.Aggregate((result, number) => result / number);
        }
    }
}
