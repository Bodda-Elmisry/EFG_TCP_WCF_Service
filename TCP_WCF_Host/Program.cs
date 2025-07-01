using EFG_TCP_WCF_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TCP_WCF_Host
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using (ServiceHost host = new ServiceHost(typeof(Service1)))
            {
                host.Open();
                Console.WriteLine("Service is running on net.tcp://localhost:9000/Service1");
                Console.WriteLine("Press Enter to stop.");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
