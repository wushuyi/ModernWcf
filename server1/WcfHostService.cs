using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServiceModelEx;
using WcfServiceLibrary1;

namespace server1
{
    class WcfHostService: IHostedService, IDisposable
    {
        private ILogger<WcfHostService> _logger;
        private ServiceHost<MyCalculator> _host;

        public WcfHostService(ILogger<WcfHostService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _host = new ServiceHost<MyCalculator>();
            _logger.LogInformation(_host.BaseAddresses.FirstOrDefault()?.AbsoluteUri);
            _host.Open();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _host.Close();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            ((IDisposable) _host)?.Dispose();
        }
    }
}
