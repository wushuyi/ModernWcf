using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using client1.ServiceReference1;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WcfServiceLibrary1;

namespace client1
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<ICalculatorResponse, MyCalculatorResponse>();
                    services.AddHostedService<WcfHostService>();
                    services.AddHostedService<RunService>();
                });
        }
    }
}