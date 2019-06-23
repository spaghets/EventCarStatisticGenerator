using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;


namespace EventCarStatisticGenerator
{
     
    class Program
    {

        static string _connectionString = "Endpoint=sb://car-statistic-eventhub.servicebus.windows.net/;SharedAccessKeyName=admin;SharedAccessKey=MvYsZTWVMGkOr4wdQ1R3aJnQa7kzfd42EJmlNR8Osts=;EntityPath=eventhub1";

        static void Main(string[] args)
        {
            var rand = new Random();
            var client = EventHubClient.CreateFromConnectionString(_connectionString);
            int carId = 42;
            CarStatistic initial = new CarStatistic()
            {
                Acceleration = 20,
                Braking = 0,
                Speed = 50,
                CarId = carId
            };

            while (true)
            {


                CarStatistic current = new CarStatistic(initial);
                initial = current;


                // Send an event to the event hub  
                var message = JsonConvert.SerializeObject(current);
                System.Threading.Thread.Sleep(1000);
                client.Send(new EventData(Encoding.UTF8.GetBytes(message)));
                Console.WriteLine("[{0}] Event transmitted", current.GuId.ToString());
            }
        }
    }
}