﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System.ServiceModel;

namespace client1.ServiceReference1 {
    using ServiceModelEx;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ICalculator")]
    public interface ICalculator {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICalculator/Add")]
        void Add(int number1, int number2);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICalculator/Add")]
        System.Threading.Tasks.Task AddAsync(int number1, int number2);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICalculatorChannel : client1.ServiceReference1.ICalculator, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CalculatorClient : ClientResponseBase<client1.ServiceReference1.ICalculator>, client1.ServiceReference1.ICalculator {
        
        public void Add(int number1, int number2) {
            base.Channel.Add(number1, number2);
        }
        
        public System.Threading.Tasks.Task AddAsync(int number1, int number2) {
            return base.Channel.AddAsync(number1, number2);
        }


        public CalculatorClient(string responseAddress) : base(responseAddress)
        {
        }

        public CalculatorClient(string responseAddress, string endpointName) : base(responseAddress, endpointName)
        {
        }

        public CalculatorClient(string responseAddress, string endpointName, string remoteAddress) : base(responseAddress, endpointName, remoteAddress)
        {
        }

        public CalculatorClient(string responseAddress, string endpointName, EndpointAddress remoteAddress) : base(responseAddress, endpointName, remoteAddress)
        {
        }

        public CalculatorClient(string responseAddress, NetMsmqBinding binding, EndpointAddress remoteAddress) : base(responseAddress, binding, remoteAddress)
        {
        }
    }
}
