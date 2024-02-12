namespace CryptoConverter.Data.Models
{
    internal class ApiModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class CryptoRoot
        {
            public string? id { get; set; }
            public string? name { get; set; }
            public int? year_established { get; set; }
            public string? country { get; set; }
            public string? description { get; set; }
            public string? url { get; set; }
            public string? image { get; set; }
            public bool? has_trading_incentive { get; set; }
            public int? trust_score { get; set; }
            public int? trust_score_rank { get; set; }
            public double? trade_volume_24h_btc { get; set; }
            public double? trade_volume_24h_btc_normalized { get; set; }
            public PriceRoot? Price { get; set; }
        }


        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Price
        {
            public double? sek { get; set; }
        }

        public class PriceRoot
        {
            public Price? gate { get; set; }
        }

    }
}
