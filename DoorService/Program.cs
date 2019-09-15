using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace DoorService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing Service...");

            // The service configuration is loaded from app.config
            using (ServiceHost host = new ServiceHost(typeof(DoorService)))
            {
                host.Opened += Host_Opened;
                host.Faulted += Host_Faulted;
                host.Open();
                Console.WriteLine(host.Description.ConfigurationName);
                foreach (ServiceEndpoint item in host.Description.Endpoints)
                {
                    Console.WriteLine(item.ListenUri);
                }

                Console.WriteLine("Service is ready for requests.  Press any key to close service.");
                Console.WriteLine();
                Console.Read();

                Console.WriteLine("Closing service...");
            }
        }

        private static void Host_Faulted(object sender, EventArgs e)
        {
            Console.WriteLine($"Communication Error: {sender}");
        }

        private static void Host_Opened(object sender, EventArgs e)
        {
            Console.WriteLine($"Host Open: {sender}");
        }
    }
}
