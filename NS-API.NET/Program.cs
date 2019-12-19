using System;

namespace NS_API.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            var ns = new NsApi("e31c404aa678410385f3559ab20c12c8");
            // var stations = ns.GetStations(query: "Hoofd").Result;
            // var station = ns.GetStation(uicCode:"8400332");
            // var station = ns.GetStation(stationCode:"HFD");
            // var disruptions = ns.GetDisruptions(true).Result;
            // var departures = ns.GetDepartures(uicCode: "8400332").Result;
            // var departures = ns.GetDepartures(stationCode: "HFD").Result;
            // var disruptions = ns.GetArrivals(uicCode: "8400332").Result;
            // var departures = ns.GetArrivals(stationCode: "HFD").Result

            Console.WriteLine("");
            Console.WriteLine("Press enter to exit... ");
            Console.ReadLine();
        }
    }
}
