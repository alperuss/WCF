using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("SERVER");
            Helper.WcfServer.Run<TestService,Data.ITest>("127.0.0.1",8080,"bilgeadam");
            Console.ReadLine();

        }
    }
}
