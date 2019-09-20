using Calculator.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Api
{
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
}
