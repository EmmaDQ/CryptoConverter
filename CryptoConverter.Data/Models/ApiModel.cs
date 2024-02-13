namespace CryptoConverter.Data.Models
{
    public class ApiModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<CryptoRoot>(myJsonResponse);
        public class CryptoRoot
        {
            public string? Id { get; set; }
            public string? Name { get; set; }
            public int? Year_established { get; set; }
            public string? Country { get; set; }
            public string? Description { get; set; }
            public string? Url { get; set; }
            public string? Symbol { get; set; }
            public bool? Has_trading_incentive { get; set; }
            public int? Trust_score { get; set; }
            public int? Trust_score_rank { get; set; }
            public double? Trade_volume_24h_btc { get; set; }
            public double? Trade_volume_24h_btc_normalized { get; set; }
            public PriceRoot? Price { get; set; }
        }


        // Root myDeserializedClass = JsonConvert.DeserializeObject<PriceRoot>(myJsonResponse);
        public class PriceModel
        {
            public decimal Sek { get; set; }
        }

        public class PriceRoot
        {
            public PriceModel? Price { get; set; }
        }

    }
}
