using System;
using System.Collections.Generic;

namespace NS_API.NET
{
    class Program
    {
        public NS_API NS_API { get; set; }
        public ReisInfoAPI ReisInfoAPI { get; set; }
        static void Main(string[] args)
        {
            NS_API NS_API = new NS_API("e31c404aa678410385f3559ab20c12c8");
            ReisInfoAPI ReisInfoAPI = new ReisInfoAPI(NS_API);

            /*
             * 
             * Test Stations
             * 
             */
            
            /*Console.WriteLine("Zoek naar stations: ");
            string query = Console.ReadLine();
            var q = ReisInfoAPI.GetStationsByQuery(query);

            Console.WriteLine("");
            foreach (var stationq in q)
            {
                Console.WriteLine(stationq.Namen.Lang + " - " + stationq.UicCode);
            }
            Console.WriteLine("");

            Console.WriteLine("Noteer stationsnummer: ");
            var uicCode = Console.ReadLine();
            var station = ReisInfoAPI.GetStationByUicCode(uicCode);

            Console.WriteLine("");
            Console.WriteLine(station.Namen.Lang + " geselecteerd. Vertrektijden op dit station: ");
            Console.WriteLine("");
            var departures = ReisInfoAPI.GetDeparturesByUicCode(station.UicCode).Result;
            foreach (var departure in departures)
            {
                Console.Write(departure.PlannedDateTime + " - " + departure.Product.CategoryCode + " richting " + departure.Direction + "\n");
            }*/

            /*
             * 
             * Test Disruptions
             * 
             */
            
            var disruptions = ReisInfoAPI.GetDisruptions().Result;
            var actualdisruptions = ReisInfoAPI.GetDisruptions(true).Result;
            
            Console.WriteLine("\nActuele verstoringen:");
            foreach (var dis in actualdisruptions)
            {
                Console.WriteLine(dis.Titel);
            }
            
            Console.WriteLine("\nAlle verstoringen:");
            foreach (var dis in disruptions)
            {
                Console.WriteLine(dis.Titel);
            }
            
            Console.WriteLine("");
            Console.WriteLine("Press enter to exit... ");
            Console.ReadLine();
        }
    }
}
