using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NS_API.NET.Trips
{
    public partial class TripsApi
    {
        [JsonProperty("trips")] public List<Trip> Trips { get; set; }

        [JsonProperty("scrollRequestBackwardContext")]
        public string ScrollRequestBackwardContext { get; set; }

        [JsonProperty("scrollRequestForwardContext")]
        public string ScrollRequestForwardContext { get; set; }
        
        public partial class Trip
        {
            [JsonProperty("uid")]
            public string Uid { get; set; }

            [JsonProperty("plannedDurationInMinutes")]
            public long PlannedDurationInMinutes { get; set; }

            [JsonProperty("transfers")]
            public long Transfers { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("legs")]
            public List<Leg> Legs { get; set; }

            [JsonProperty("overviewPolyLine")]
            public List<object> OverviewPolyLine { get; set; }

            [JsonProperty("checksum")]
            public string Checksum { get; set; }

            [JsonProperty("crowdForecast")]
            public string CrowdForecast { get; set; }

            [JsonProperty("punctuality")]
            public double Punctuality { get; set; }

            [JsonProperty("ctxRecon")]
            public string CtxRecon { get; set; }

            [JsonProperty("actualDurationInMinutes")]
            public long ActualDurationInMinutes { get; set; }

            [JsonProperty("idx")]
            public long Idx { get; set; }

            [JsonProperty("optimal")]
            public bool Optimal { get; set; }

            [JsonProperty("fares", NullValueHandling = NullValueHandling.Ignore)]
            public List<Fare> Fares { get; set; }

            [JsonProperty("productFare", NullValueHandling = NullValueHandling.Ignore)]
            public ProductFare ProductFare { get; set; }

            [JsonProperty("fareOptions")]
            public FareOptions FareOptions { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("shareUrl")]
            public ShareUrl ShareUrl { get; set; }

            [JsonProperty("realtime")]
            public bool Realtime { get; set; }

            [JsonProperty("routeId", NullValueHandling = NullValueHandling.Ignore)]
            public string RouteId { get; set; }
        }

        public partial class FareOptions
        {
            [JsonProperty("isInternationalBookable")]
            public bool IsInternationalBookable { get; set; }

            [JsonProperty("isInternational")]
            public bool IsInternational { get; set; }

            [JsonProperty("isEticketBuyable")]
            public bool IsEticketBuyable { get; set; }

            [JsonProperty("isPossibleWithOvChipkaart")]
            public bool IsPossibleWithOvChipkaart { get; set; }
        }

        public partial class Fare
        {
            [JsonProperty("priceInCents")]
            public long PriceInCents { get; set; }

            [JsonProperty("product")]
            public string Product { get; set; }

            [JsonProperty("travelClass")]
            public string TravelClass { get; set; }

            [JsonProperty("discountType")]
            public string DiscountType { get; set; }
        }

        public partial class Leg
        {
            [JsonProperty("idx")]
            public string Idx { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("travelType")]
            public string TravelType { get; set; }

            [JsonProperty("direction", NullValueHandling = NullValueHandling.Ignore)]
            public string Direction { get; set; }

            [JsonProperty("cancelled")]
            public bool Cancelled { get; set; }

            [JsonProperty("changePossible")]
            public bool ChangePossible { get; set; }

            [JsonProperty("alternativeTransport")]
            public bool AlternativeTransport { get; set; }

            [JsonProperty("journeyDetailRef")]
            public string JourneyDetailRef { get; set; }

            [JsonProperty("origin")]
            public Origin Origin { get; set; }

            [JsonProperty("destination")]
            public Destination Destination { get; set; }

            [JsonProperty("product")]
            public Product Product { get; set; }

            [JsonProperty("notes")]
            public List<LegNote> Notes { get; set; }

            [JsonProperty("messages")]
            public List<object> Messages { get; set; }

            [JsonProperty("stops")]
            public List<Stop> Stops { get; set; }

            [JsonProperty("steps")]
            public List<object> Steps { get; set; }

            [JsonProperty("punctuality")]
            public double Punctuality { get; set; }

            [JsonProperty("shorterStock")]
            public bool ShorterStock { get; set; }

            [JsonProperty("journeyDetail")]
            public List<JourneyDetail> JourneyDetail { get; set; }

            [JsonProperty("reachable")]
            public bool Reachable { get; set; }

            [JsonProperty("crowdForecast", NullValueHandling = NullValueHandling.Ignore)]
            public string CrowdForecast { get; set; }

            [JsonProperty("crossPlatformTransfer", NullValueHandling = NullValueHandling.Ignore)]
            public bool? CrossPlatformTransfer { get; set; }
        }

        public partial class Destination
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("prognosisType")]
            public string PrognosisType { get; set; }

            [JsonProperty("plannedTimeZoneOffset")]
            public long PlannedTimeZoneOffset { get; set; }

            [JsonProperty("plannedDateTime")]
            public string PlannedDateTime { get; set; }

            [JsonProperty("actualTimeZoneOffset", NullValueHandling = NullValueHandling.Ignore)]
            public long? ActualTimeZoneOffset { get; set; }

            [JsonProperty("actualDateTime", NullValueHandling = NullValueHandling.Ignore)]
            public string ActualDateTime { get; set; }

            [JsonProperty("plannedTrack", NullValueHandling = NullValueHandling.Ignore)]
            public string PlannedTrack { get; set; }

            [JsonProperty("exitSide", NullValueHandling = NullValueHandling.Ignore)]
            public string ExitSide { get; set; }

            [JsonProperty("checkinStatus")]
            public string CheckinStatus { get; set; }

            [JsonProperty("notes")]
            public List<DestinationNote> Notes { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("lng")]
            public double Lng { get; set; }

            [JsonProperty("lat")]
            public double Lat { get; set; }

            [JsonProperty("countryCode")]
            public string CountryCode { get; set; }

            [JsonProperty("uicCode")]
            public string UicCode { get; set; }

            [JsonProperty("weight")]
            public long Weight { get; set; }

            [JsonProperty("products")]
            public long Products { get; set; }
        }

        public partial class DestinationNote
        {
            [JsonProperty("value")]
            public string Value { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("noteType")]
            public string NoteType { get; set; }

            [JsonProperty("priority", NullValueHandling = NullValueHandling.Ignore)]
            public long? Priority { get; set; }

            [JsonProperty("isPresentationRequired")]
            public bool IsPresentationRequired { get; set; }

            [JsonProperty("category")]
            public string Category { get; set; }
        }

        public partial class JourneyDetail
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("link")]
            public ShareUrl Link { get; set; }
        }

        public partial class ShareUrl
        {
            [JsonProperty("uri")]
            public Uri Uri { get; set; }
        }

        public partial class LegNote
        {
            [JsonProperty("value")]
            public string Value { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("noteType")]
            public string NoteType { get; set; }

            [JsonProperty("priority")]
            public long Priority { get; set; }

            [JsonProperty("routeIdxFrom")]
            public long RouteIdxFrom { get; set; }

            [JsonProperty("routeIdxTo")]
            public long RouteIdxTo { get; set; }

            [JsonProperty("isPresentationRequired")]
            public bool IsPresentationRequired { get; set; }

            [JsonProperty("category")]
            public string Category { get; set; }
        }

        public partial class Origin
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("prognosisType")]
            public string PrognosisType { get; set; }

            [JsonProperty("plannedTimeZoneOffset")]
            public long PlannedTimeZoneOffset { get; set; }

            [JsonProperty("plannedDateTime")]
            public string PlannedDateTime { get; set; }

            [JsonProperty("actualTimeZoneOffset", NullValueHandling = NullValueHandling.Ignore)]
            public long? ActualTimeZoneOffset { get; set; }

            [JsonProperty("actualDateTime", NullValueHandling = NullValueHandling.Ignore)]
            public string ActualDateTime { get; set; }

            [JsonProperty("plannedTrack", NullValueHandling = NullValueHandling.Ignore)]
            public string PlannedTrack { get; set; }

            [JsonProperty("checkinStatus")]
            public string CheckinStatus { get; set; }

            [JsonProperty("notes")]
            public List<DestinationNote> Notes { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("lng")]
            public double Lng { get; set; }

            [JsonProperty("lat")]
            public double Lat { get; set; }

            [JsonProperty("countryCode")]
            public string CountryCode { get; set; }

            [JsonProperty("uicCode")]
            public string UicCode { get; set; }

            [JsonProperty("weight")]
            public long Weight { get; set; }

            [JsonProperty("products")]
            public long Products { get; set; }
        }

        public partial class Product
        {
            [JsonProperty("number")]
            public string Number { get; set; }

            [JsonProperty("categoryCode")]
            public string CategoryCode { get; set; }

            [JsonProperty("shortCategoryName")]
            public string ShortCategoryName { get; set; }

            [JsonProperty("longCategoryName")]
            public string LongCategoryName { get; set; }

            [JsonProperty("operatorCode")]
            public string OperatorCode { get; set; }

            [JsonProperty("operatorName")]
            public string OperatorName { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("displayName")]
            public string DisplayName { get; set; }
        }

        public partial class Stop
        {
            [JsonProperty("notes")]
            public List<StopNote> Notes { get; set; }

            [JsonProperty("routeIdx", NullValueHandling = NullValueHandling.Ignore)]
            public long? RouteIdx { get; set; }

            [JsonProperty("departurePrognosisType", NullValueHandling = NullValueHandling.Ignore)]
            public string DeparturePrognosisType { get; set; }

            [JsonProperty("plannedDepartureDateTime", NullValueHandling = NullValueHandling.Ignore)]
            public string PlannedDepartureDateTime { get; set; }

            [JsonProperty("plannedDepartureTimeZoneOffset", NullValueHandling = NullValueHandling.Ignore)]
            public long? PlannedDepartureTimeZoneOffset { get; set; }

            [JsonProperty("actualDepartureDateTime", NullValueHandling = NullValueHandling.Ignore)]
            public string ActualDepartureDateTime { get; set; }

            [JsonProperty("plannedDepartureTrack", NullValueHandling = NullValueHandling.Ignore)]
            public string PlannedDepartureTrack { get; set; }

            [JsonProperty("plannedArrivalDateTime", NullValueHandling = NullValueHandling.Ignore)]
            public string PlannedArrivalDateTime { get; set; }

            [JsonProperty("plannedArrivalTimeZoneOffset", NullValueHandling = NullValueHandling.Ignore)]
            public long? PlannedArrivalTimeZoneOffset { get; set; }

            [JsonProperty("plannedArrivalTrack", NullValueHandling = NullValueHandling.Ignore)]
            public string PlannedArrivalTrack { get; set; }

            [JsonProperty("cancelled", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Cancelled { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("lng")]
            public double Lng { get; set; }

            [JsonProperty("lat")]
            public double Lat { get; set; }

            [JsonProperty("countryCode")]
            public string CountryCode { get; set; }

            [JsonProperty("uicCode")]
            public string UicCode { get; set; }

            [JsonProperty("actualDepartureTrack", NullValueHandling = NullValueHandling.Ignore)]
            public string ActualDepartureTrack { get; set; }

            [JsonProperty("arrivalPrognosisType", NullValueHandling = NullValueHandling.Ignore)]
            public string ArrivalPrognosisType { get; set; }

            [JsonProperty("actualArrivalDateTime", NullValueHandling = NullValueHandling.Ignore)]
            public string ActualArrivalDateTime { get; set; }

            [JsonProperty("actualArrivalTrack", NullValueHandling = NullValueHandling.Ignore)]
            public string ActualArrivalTrack { get; set; }

            [JsonProperty("passing", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Passing { get; set; }
        }

        public partial class StopNote
        {
            [JsonProperty("value")]
            public string Value { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("priority")]
            public long Priority { get; set; }
        }

        public partial class ProductFare
        {
            [JsonProperty("priceInCents")]
            public long PriceInCents { get; set; }

            [JsonProperty("product")]
            public string Product { get; set; }

            [JsonProperty("travelClass")]
            public string TravelClass { get; set; }

            [JsonProperty("priceInCentsExcludingSupplement")]
            public long PriceInCentsExcludingSupplement { get; set; }

            [JsonProperty("discountType")]
            public string DiscountType { get; set; }
        }
    }
}