using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class TestService : Data.ITest
    {
        public DateTime GetServerTime()
        {
            return DateTime.Now;
        }
    }
}
