using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceModelEx;

namespace client1
{
    internal class DIServiceHost<T> : ServiceHost<T>
    {
        private void InitDI(IServiceProvider serviceProvider)
        {
            foreach (var contractDescription in ImplementedContracts.Values)
            {
                var diInstanceProvider = new DIInstanceProvider(serviceProvider, contractDescription.ContractType);
                var contractBehavior = new DIContractBehavior(diInstanceProvider);

                contractDescription.Behaviors.Add(contractBehavior);
            }
        }

        public DIServiceHost(IServiceProvider serviceProvider)
        {
            InitDI(serviceProvider);
        }

        public DIServiceHost(IServiceProvider serviceProvider, params string[] baseAddresses) : base(baseAddresses)
        {
            InitDI(serviceProvider);
        }

        public DIServiceHost(IServiceProvider serviceProvider, params Uri[] baseAddresses) : base(baseAddresses)
        {
            InitDI(serviceProvider);
        }

        public DIServiceHost(IServiceProvider serviceProvider, T singleton, params string[] baseAddresses) : base(
            singleton, baseAddresses)
        {
            InitDI(serviceProvider);
        }

        public DIServiceHost(IServiceProvider serviceProvider, T singleton) : base(singleton)
        {
            InitDI(serviceProvider);
        }

        public DIServiceHost(IServiceProvider serviceProvider, T singleton, params Uri[] baseAddresses) : base(
            singleton, baseAddresses)
        {
            InitDI(serviceProvider);
        }
    }

    internal class DIContractBehavior : IContractBehavior
    {
        private readonly IInstanceProvider instanceProvider;

        public DIContractBehavior(IInstanceProvider instanceProvider)
        {
            this.instanceProvider = instanceProvider;
        }

        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint,
            BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint,
            ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint,
            DispatchRuntime dispatchRuntime)
        {
            dispatchRuntime.InstanceProvider = instanceProvider;
            dispatchRuntime.InstanceContextInitializers.Add(new DIInstanceContextInitializer());
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }
    }

    internal class DIInstanceContextInitializer : IInstanceContextInitializer
    {
        public void Initialize(InstanceContext instanceContext, Message message)
        {
            instanceContext.Extensions.Add(new DIExtension());
        }
    }

    internal class DIExtension : IExtension<InstanceContext>
    {
        private IServiceScope serviceScope;

        public IServiceScope GetServiceScope(IServiceProvider serviceProvider)
        {
            return serviceScope = serviceScope ??
                                  (serviceScope = serviceProvider.CreateScope());
        }

        public void ReleaseServiceScope()
        {
            serviceScope?.Dispose();
        }

        public void Attach(InstanceContext owner)
        {
        }

        public void Detach(InstanceContext owner)
        {
        }
    }

    internal class DIInstanceProvider : IInstanceProvider
    {
        private readonly IServiceProvider serviceProvider;
        private readonly Type contractType;

        public DIInstanceProvider(IServiceProvider serviceProvider, Type contractType)
        {
            this.serviceProvider = serviceProvider;
            this.contractType = contractType;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            var diExtension = instanceContext.Extensions.Find<DIExtension>();
            var serviceScope = diExtension.GetServiceScope(serviceProvider);
            return serviceScope.ServiceProvider.GetService(contractType);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            var diExtension = instanceContext.Extensions.Find<DIExtension>();
            diExtension.ReleaseServiceScope();
        }
    }
}