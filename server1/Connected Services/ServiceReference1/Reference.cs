﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace server1.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ICalculatorResponse")]
    public interface ICalculatorResponse {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICalculatorResponse/OnAddCompleted")]
        void OnAddCompleted(int result, System.ServiceModel.ExceptionDetail error);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICalculatorResponse/OnAddCompleted")]
        System.Threading.Tasks.Task OnAddCompletedAsync(int result, System.ServiceModel.ExceptionDetail error);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICalculatorResponseChannel : server1.ServiceReference1.ICalculatorResponse, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CalculatorResponseClient : System.ServiceModel.ClientBase<server1.ServiceReference1.ICalculatorResponse>, server1.ServiceReference1.ICalculatorResponse {
        
        public CalculatorResponseClient() {
        }
        
        public CalculatorResponseClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CalculatorResponseClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculatorResponseClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculatorResponseClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void OnAddCompleted(int result, System.ServiceModel.ExceptionDetail error) {
            base.Channel.OnAddCompleted(result, error);
        }
        
        public System.Threading.Tasks.Task OnAddCompletedAsync(int result, System.ServiceModel.ExceptionDetail error) {
            return base.Channel.OnAddCompletedAsync(result, error);
        }
    }
}