using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.ServiceBus.Messaging;

namespace ReadQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            //var conn = ConfigurationManager.AppSettings["connectionString"];
            var conn = "Endpoint=sb://demo444.servicebus.windows.net/;SharedSecretIssuer=owner;SharedSecretValue=58A9PGyNb5Qayh8zkYxAj0cDtAKKjlRcyvoyqJSr8do=";

            var cl = QueueClient.CreateFromConnectionString(conn, "incidencias");

            while (true)
            {
                var msg = cl.Receive();

                if (msg != null)
                {
                    Console.WriteLine("Mensaje: ");
                    Console.WriteLine("Incidencia {0} fecha {1}", msg.Properties["incidencia"], msg.Properties["fecha"]);

                    msg.Complete();
                }
            }
        }
    }
}
