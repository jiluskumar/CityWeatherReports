using System;
using System.Collections.Generic;

namespace CityWeatherReports.DBModels
{
    public partial class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Country { get; set; } = null!;
        public short TouristRating { get; set; }
        public string? TwoDigitCountryCode { get; set; }
        public string? ThreeDigitCountryCode { get; set; }
        public short CityWeather { get; set; }
        public DateTime DateEstablisted { get; set; }
        public int EstimatedPopulation { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
