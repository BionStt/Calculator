namespace Calculator.Domain
{
    public interface IOperation
    {
        decimal Calculate(decimal[] numbers);
    }
}
