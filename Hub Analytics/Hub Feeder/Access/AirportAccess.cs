using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hub_Feeder.Access
{
    public class AirportAccess
    {
        public List<Model.Airport> GetAllUSAirports()
        {
            List<Model.Airport> airports = new List<Model.Airport>();

            var lines = System.IO.File.ReadAllLines("test.txt").Select(a => a.Split(','));

            foreach (var row in lines)
            {
                var airport = new Model.Airport() { Code = row[3], Country = row[2] };

                if (airport.Country.ToLower() == "united states")
                    airports.Add(airport);
            }

            return airports;
        }
    }
}
