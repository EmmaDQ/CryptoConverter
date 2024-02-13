using Newtonsoft.Json;

namespace CryptoConverter.Data.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<CryptoRoot>(myJsonResponse);
    public class CryptoRoot
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("year_established")]
        public int Year_established { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("image")]
        public string Symbol { get; set; }

        [JsonProperty("has_trading_incentive")]
        public bool Has_trading_incentive { get; set; }

        [JsonProperty("trust_score")]
        public int Trust_score { get; set; }

        [JsonProperty("trust_score_rank")]
        public int Trust_score_rank { get; set; }

        [JsonProperty("trade_volume_24h_btc")]
        public double Trade_volume_24h_btc { get; set; }

        [JsonProperty("trade_volume_24h_btc_normalized")]
        public double Trade_volume_24h_btc_normalized { get; set; }
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<PriceRoot>(myJsonResponse);
    public class PriceModel
    {
        [JsonProperty("sek")]
        public decimal Sek { get; set; }
    }

    public class PriceRoot
    {
        [JsonProperty("Price")]
        public PriceModel? Price { get; set; }
    }


}

