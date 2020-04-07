using Data;
using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CLIENT");
            var test =WcfClient<ITest>.Channel("http://127.0.0.1:8080/bilgeadam");

            while (true)
            {
                var serverDate = test.GetServerTime();
                Console.WriteLine(serverDate);

                Thread.Sleep(1000);
            }

            Console.ReadLine();
        }
    }
}
