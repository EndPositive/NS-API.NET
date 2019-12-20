using System;

namespace NS_API.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            var ns = new NsApi("e31c404aa678410385f3559ab20c12c8");
            // var stations    = ns.GetStations(query: "Hoofd").Result;
            // var station     = ns.GetStation(8400332);
            // var station     = ns.GetStation("HFD");
            
            // var disruptions = ns.GetDisruptions(true).Result;
            // var disruption  = ns.GetDisruption("1da66eef-5944-4259-903c-b113827c29a6").Result;
            // var disruptions = ns.GetStationDisruptions("ASD").Result;
            
            // var departures  = ns.GetDepartures(uicCode: "8400332").Result;
            // var departures  = ns.GetDepartures(stationCode: "HFD").Result;
            
            // var disruptions = ns.GetArrivals(uicCode: "8400332").Result;
            // var departures  = ns.GetArrivals(stationCode: "HFD").Result;
            
            // var calamities  = ns.GetCalamities().Result;

            // var trips = ns.GetTrips("HFD","ASD").Result;
            // var trips = ns.GetTrips(8400332, 8400058).Result;

            Console.WriteLine("");
            Console.WriteLine("Press enter to exit... ");
            Console.ReadLine();
        }
    }
}
