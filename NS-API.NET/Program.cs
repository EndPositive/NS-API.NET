using System;

namespace NS_API.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            var ns = new NsApi("e31c404aa678410385f3559ab20c12c8");
            // var q = ns.GetStationsByQuery("Hoofddorp");
            // var station = ns.GetStationByUicCode("8400332");
            // var departures = ns.GetDeparturesByUicCode(station.UicCode).Result;
            // var disruptions = ns.GetDisruptions(true).Result;
            
            Console.WriteLine("");
            Console.WriteLine("Press enter to exit... ");
            Console.ReadLine();
        }
    }
}
