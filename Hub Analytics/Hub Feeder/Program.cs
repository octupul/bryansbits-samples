using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hub_Feeder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1 && HelpRequired(args[0]))
            {
                DisplayHelp();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Dictionary<string, string> values = new Dictionary<string, string>();

            // pull arguments out as pairs
            for (int i = 0; i < args.Length; i += 2)
            {
                if(args.Length > i + 1)
                {
                    values.Add(args[i], args[i + 1]);
                }
            }

            // Access json formatted settings found in 'settings.json' in exe folder
            Access.HubSettings hs = Access.HubSettings.GetSettings();
            string format = values.ContainsKey("-format") ? values["-format"] : "eventhub";

            Access.EvenHubAccess eventHub = new Access.EvenHubAccess(hs.EventHubConnectionString);

            if (format != "eventhub" && format != "iothub")
            {
                format = "eventhub";
            }

            // Spin up eventhub
            if(format == "eventhub")
            {
                while(true)
                {
                    // Get random sentence
                    Model.Comment com = Model.Comment.GetRandomSentence();

                    // Write sentence to event hub
                    eventHub.AddToHub(com);
                    Console.Write(Newtonsoft.Json.JsonConvert.SerializeObject(com));
                    Console.WriteLine();
                    System.Threading.Thread.Sleep(1000);

                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static bool HelpRequired(string param)
        {
            return param == "-h" || param == "--help" || param == "/?";
        }

        private static void DisplayHelp()
        {
            Console.WriteLine("Hub Feeder Commands");
            Console.WriteLine("-format [eventhub|iothub");
        }
    }
}
