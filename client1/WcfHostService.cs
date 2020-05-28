using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServiceModelEx;

namespace client1
{
    class WcfHostService: IHostedService, IDisposable
    {
        private ILogger<WcfHostService> _logger;
        private ServiceHost<MyCalculatorResponse> _host;
        private IServiceProvider _serviceProvider;

        public WcfHostService(ILogger<WcfHostService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _host = new DIServiceHost<MyCalculatorResponse>(_serviceProvider);
            //_host = new ServiceHost<MyCalculatorResponse>();
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
