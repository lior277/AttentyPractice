using Newtonsoft.Json;
using System;

namespace AttentyPracticeFrameWork.Dto_s
{

    public partial class GetWeatherResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("vt1observation")]
        public Vt1Observation Vt1Observation { get; set; }
    }

    public partial class Vt1Observation
    {
        [JsonProperty("altimeter")]
        public double Altimeter { get; set; }

        [JsonProperty("barometerTrend")]
        public string BarometerTrend { get; set; }

        [JsonProperty("barometerCode")]
        public long BarometerCode { get; set; }

        [JsonProperty("barometerChange")]
        public double BarometerChange { get; set; }

        [JsonProperty("dewPoint")]
        public long DewPoint { get; set; }

        [JsonProperty("feelsLike")]
        public long FeelsLike { get; set; }

        [JsonProperty("gust")]
        public object Gust { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("icon")]
        public long Icon { get; set; }

        [JsonProperty("observationTime")]
        public string ObservationTime { get; set; }

        [JsonProperty("obsQualifierCode")]
        public object ObsQualifierCode { get; set; }

        [JsonProperty("obsQualifierSeverity")]
        public object ObsQualifierSeverity { get; set; }

        [JsonProperty("phrase")]
        public string Phrase { get; set; }

        [JsonProperty("precip24Hour")]
        public long Precip24Hour { get; set; }

        [JsonProperty("snowDepth")]
        public long SnowDepth { get; set; }

        [JsonProperty("temperature")]
        public long Temperature { get; set; }

        [JsonProperty("temperatureMaxSince7am")]
        public long TemperatureMaxSince7Am { get; set; }

        [JsonProperty("uvIndex")]
        public long UvIndex { get; set; }

        [JsonProperty("uvDescription")]
        public string UvDescription { get; set; }

        [JsonProperty("visibility")]
        public long Visibility { get; set; }

        [JsonProperty("windSpeed")]
        public long WindSpeed { get; set; }

        [JsonProperty("windDirCompass")]
        public string WindDirCompass { get; set; }

        [JsonProperty("windDirDegrees")]
        public long WindDirDegrees { get; set; }
    }

}
