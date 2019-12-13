using System;

namespace NS_API.NET
{
    class Program
    {
        public NsApi Ns { get; set; }
        static void Main(string[] args)
        {
            NsApi ns = new NsApi("e31c404aa678410385f3559ab20c12c8");

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
            
            var disruptions = ns.GetDisruptions().Result;
            var actualdisruptions = ns.GetDisruptions(true).Result;
            
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
