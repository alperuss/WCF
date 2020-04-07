using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class WcfClient<T1>
    {
        private static T1 _channelS = default(T1);
        public static T1 Channel(string endpoint)
        {
            if (_channelS != null) return _channelS;

            BasicHttpBinding basicHttpBinding = new BasicHttpBinding() { 
            
            MaxReceivedMessageSize =long.MaxValue,
            MaxBufferPoolSize=long.MaxValue,
            MaxBufferSize=int.MaxValue,
            ReceiveTimeout=TimeSpan.MaxValue,
            TransferMode=TransferMode.Streamed,
            SendTimeout=TimeSpan.MaxValue
            
            };

            EndpointAddress endpointAddress = new EndpointAddress(endpoint);

            ChannelFactory<T1> channelFactory = new ChannelFactory<T1>(basicHttpBinding, endpointAddress);

            T1 channel = channelFactory.CreateChannel();

            _channelS = channel;

            return channel;
        }
    }
}
