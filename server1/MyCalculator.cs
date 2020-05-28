using System;
using System.ServiceModel;
using server1.ServiceReference1;
using WcfServiceLibrary1;

namespace server1
{
    public class MyCalculator: ICalculator
    {
        [OperationBehavior(TransactionScopeRequired = true)]
        public void Add(int number1, int number2)
        {
            Console.WriteLine($"num1: {number1}, num2: {number2}");
            int result = 0;
            ExceptionDetail error = null;

            try
            {
                result = number1 + number2;
            }
            catch (Exception e)
            {
                error = new ExceptionDetail(e);
            }
            finally
            {
                var proxy = new CalculatorResponseClient();

                proxy.OnAddCompleted(result, error);

                proxy.Close();
            }
        }
    }
}
