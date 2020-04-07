using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class WcfServer
    {
        public static ServiceHost Run<T1,T2>(string ipAddress, int port, string serviceName)
        {
            Uri uri = new Uri("http://"+ ipAddress + ":" + port + "/" + serviceName);

            ServiceHost serviceHost = new ServiceHost(typeof(T1),uri);

            serviceHost.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            serviceHost.Description.Behaviors.Add(new ServiceDebugBehavior()
            {

                IncludeExceptionDetailInFaults = true

            });
            ServiceMetadataBehavior serviceMetadataBehavior = new ServiceMetadataBehavior() {

                HttpGetEnabled = true
            };
            BasicHttpBinding basicHttpBinding = new BasicHttpBinding() { 
            
                MaxReceivedMessageSize=int.MaxValue,
                MaxBufferSize=int.MaxValue,
                MaxBufferPoolSize=int.MaxValue,
                ReceiveTimeout =new TimeSpan(int.MaxValue),
                SendTimeout =TimeSpan.MaxValue,
                TransferMode=TransferMode.Streamed
            
            
            };

            serviceHost.AddServiceEndpoint(typeof(T2), basicHttpBinding, uri);
            serviceHost.Description.Behaviors.Add(serviceMetadataBehavior);
            
            serviceHost.Open();

            Console.WriteLine("WCF is live now at {0}",uri);

            return serviceHost;
        }
    }
}
