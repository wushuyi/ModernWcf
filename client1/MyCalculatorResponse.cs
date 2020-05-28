using System;
using System.ServiceModel;
using Microsoft.Extensions.Logging;
using ServiceModelEx;
using WcfServiceLibrary1;

namespace client1
{
    public class MyCalculatorResponse: ICalculatorResponse
    {
        private ILogger<MyCalculatorResponse> _logger;

        public MyCalculatorResponse(ILogger<MyCalculatorResponse> logger)
        {
            _logger = logger;
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void OnAddCompleted(int result, ExceptionDetail error)
        {
            //var methodId = ResponseContext.Current.MethodId;
            if (error != null)
            {
                _logger.LogInformation("{0}",error);
            }
            else
            {
                _logger.LogInformation("Result = {0}",result);
            }
        }
    }
}
