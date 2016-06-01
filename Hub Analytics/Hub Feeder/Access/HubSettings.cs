using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hub_Feeder.Access
{
    public class HubSettings
    {
        public string EventHubConnectionString { get; set; }
        public string IOTConnectionString { get; set; }

        public static HubSettings GetSettings()
        {
            using (StreamReader sr = new StreamReader("settings.json"))
            {
                String line = sr.ReadToEnd();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<HubSettings>(line);
            }
        }
    }
}
