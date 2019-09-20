using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Calculator.Api
{
    public class Program
    {
        public static void Main()
        {
            WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build().Run();
        }
    }
}
