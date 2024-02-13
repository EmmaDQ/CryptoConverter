using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CryptoConverter.Data.Models
{
    public class ApiModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<CryptoRoot>(myJsonResponse);
        public class Root
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("symbol")]
            public string Symbol { get; set; }

            [JsonProperty("market_cap_rank")]
            public int? MarketCapRank { get; set; }

        }


		// Root myDeserializedClass = JsonConvert.DeserializeObject<PriceRoot>(myJsonResponse);
		public class PriceRoot
		{
			[JsonExtensionData]
			public Dictionary<string, JToken> Prices { get; set; }
		}

		public class PriceModel
		{
			public PriceRoot CryptoPrices { get; set; }
		}
	}
}



