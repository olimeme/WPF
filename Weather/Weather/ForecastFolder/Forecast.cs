using System.Collections.Generic;
using Weather.Forecast;

namespace Weather
{
    public class ForeCast
    {
        public Headline Headline { get; set; }
        public List<DailyForecast> DailyForecasts { get; set; }
    }
}
