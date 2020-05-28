using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using client1.ServiceReference1;
using Microsoft.Extensions.Hosting;

namespace client1
{
    internal class RunService : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var responseAddress = "net.msmq://localhost/private/CalculatorResponse";
            var proxy = new CalculatorClient(responseAddress);
            await proxy.AddAsync(2, 3);
            var methodId = proxy.Header.MethodId;
            proxy.Close();
        }
    }
}