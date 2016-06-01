using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace Hub_Feeder.Access
{
    public class EvenHubAccess
    {
        private string _hubName;
        private string _connectionString;
        EventHubClient _hubClient;
        public EvenHubAccess(string connString)
        {
            _connectionString = connString;
            _hubClient = EventHubClient.CreateFromConnectionString(connString);
        }


        public void AddToHub(object message)
        {

            _hubClient.Send(new EventData(Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(message))));
        }
    }
}
