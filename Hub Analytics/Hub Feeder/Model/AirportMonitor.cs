using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hub_Feeder.Model
{
   public class AirportMonitor
    {
        public string AirportCode { get; set; }
        public DateTime TimeStamp { get; set; }
        public int Temp { get; set; }
        public int NumEnteringAirport { get; set; }
    }
}
