using Newtonsoft.Json;

namespace QuarterService.Infrastructure.DTO
{
    public class CandlestickDataBinance
    {
        [JsonProperty(Order = 0)]
        public long OpenTime { get; set; }

        [JsonProperty(Order = 1)]
        public string Open { get; set; }

        [JsonProperty(Order = 2)]
        public string High { get; set; }

        [JsonProperty(Order = 3)]
        public string Low { get; set; }

        [JsonProperty(Order = 4)]
        public string Close { get; set; }

        [JsonProperty(Order = 5)]
        public string Volume { get; set; }

        [JsonProperty(Order = 6)]
        public long CloseTime { get; set; }

        [JsonProperty(Order = 7)]
        public string QuoteAssetVolume { get; set; }

        [JsonProperty(Order = 8)]
        public int NumberOfTrades { get; set; }

        [JsonProperty(Order = 9)]
        public string TakerBuyBaseAssetVolume { get; set; }

        [JsonProperty(Order = 10)]
        public string TakerBuyQuoteAssetVolume { get; set; }

        [JsonProperty(Order = 11)]
        public string Ignore { get; set; }
    }
}
