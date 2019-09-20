# Calculator

ASP.NET Core API example.

## Postman

POST: https://localhost:5000/Calculator

```js
{
    Numbers: [10, 20, 30, 40, 50],
    Operation: 1
}
```

## API

### Startup

```cs
public class Startup
{
    public void Configure(IApplicationBuilder application)
    {
        application.UseDeveloperExceptionPage();
        application.UseCors(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        application.UseHttpsRedirection();
        application.UseMvcWithDefaultRoute();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ICalculatorService, CalculatorService>();
        services.AddCors();
        services.AddMvc();
    }
}
```

### Controller

```cs
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
```

## Domain

### Calculation

```cs
public class Calculation
{
    public decimal[] Numbers { get; set; }

    public Operation Operation { get; set; }
}
```

### CalculatorService

```cs
public interface ICalculatorService
{
    decimal Calculate(Calculation calculation);
}
```

```cs
public class CalculatorService : ICalculatorService
{
    public decimal Calculate(Calculation calculation)
    {
        var operation = Factory.Get<IOperation>(calculation.Operation.ToString());

        if (operation == null) { return 0; }

        return operation.Calculate(calculation.Numbers);
    }
}
```

### Operation

```cs
public enum Operation
{
    Addition = 1,
    Subtraction = 2,
    Multiplication = 3,
    Division = 4
}
```

```cs
public interface IOperation
{
    decimal Calculate(decimal[] numbers);
}
```

```cs
public class Addition : IOperation
{
    public decimal Calculate(decimal[] numbers)
    {
        return numbers.Aggregate((result, number) => result + number);
    }
}
```

```cs
public class Subtraction : IOperation
{
    public decimal Calculate(decimal[] numbers)
    {
        return numbers.Aggregate((result, number) => result - number);
    }
}
```

```cs
public class Division : IOperation
{
    public decimal Calculate(decimal[] numbers)
    {
        if (numbers.Any(x => x == 0)) { return 0; }

        return numbers.Aggregate((result, number) => result / number);
    }
}
```

```cs
public class Multiplication : IOperation
{
    public decimal Calculate(decimal[] numbers)
    {
        return numbers.Aggregate((result, number) => result * number);
    }
}
```
