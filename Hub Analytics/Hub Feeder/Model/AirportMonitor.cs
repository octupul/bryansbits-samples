using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;
using Newtonsoft.Json;

namespace Hub_Feeder.Model
{
   public class AirportMonitor
    {
        public string AirportCode { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal Temp { get; set; }
        public int NumEnteringAirport { get; set; }
        [JsonIgnore]
        public Device Device { get; set; }

        public void UpdateData()
        {
            Random rand = new Random();
            decimal tempChange;
            if(DateTime.Now.Hour < 12) { 
            
                // perfer down
                tempChange = rand.Next(-10, 4) / 10;
            }else
            {
                // perfer up
                tempChange = rand.Next(-4, 10) / 10;
            }

            Temp += tempChange;

            NumEnteringAirport += rand.Next(20);

            TimeStamp = DateTime.Now;
        }
    }
}
