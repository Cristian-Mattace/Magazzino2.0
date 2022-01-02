using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            try {

                ServiceHost svcHost = new ServiceHost(typeof(Service1));
                svcHost.Open();
                Console.WriteLine("APERTO");
                Console.ReadLine();

                svcHost.Close();
                Console.WriteLine("chiuso");

            }
            catch (Exception e) {
                
            }
        }
    }
}
