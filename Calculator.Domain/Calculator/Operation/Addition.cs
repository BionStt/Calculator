using System.Linq;

namespace Calculator.Domain
{
    public class Addition : IOperation
    {
        public decimal Calculate(decimal[] numbers)
        {
            return numbers.Aggregate((result, number) => result + number);
        }
    }
}
