using CryptoConverter.Data.Database;
using CryptoConverter.Data.Database.Repositories;
using CryptoConverter.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static CryptoConverter.Data.Models.ApiModel;


namespace CryptoConverter.App.ApiCaller
{
    public class CryptoApiCaller
    {
        private readonly HttpClient _httpClient;
        private readonly AppDbContext _dbContext;

        public CryptoApiCaller(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.coingecko.com/api/v3/");
            
        }

        public async Task<Root> MakeCall(string id)
        {
            try
            {

                HttpResponseMessage responseCrypto = await _httpClient.GetAsync($"https://api.coingecko.com/api/v3//coins/{id.ToLower()}");
                HttpResponseMessage responsePrice = await _httpClient.GetAsync($"https://api.coingecko.com/api/v3/simple/price?ids={id.ToLower()}&vs_currencies=sek");

                if (responseCrypto.IsSuccessStatusCode)
                {
                    string jsonCrypto = await responseCrypto.Content.ReadAsStringAsync();
                    string jsonPrice = await responsePrice.Content.ReadAsStringAsync();
                    Root? resultCrypto = JsonConvert.DeserializeObject<Root>(jsonCrypto);
                    PriceRoot? resultPrice = JsonConvert.DeserializeObject<PriceRoot>(jsonPrice);

                    if (resultCrypto != null && resultPrice != null && resultPrice.Prices.ContainsKey(id))
                    {


                        CryptoModel crypto = new()
                        {
                            cryptoAPI_Id = id,
                            Symbol = resultCrypto.Symbol,
                            Name = resultCrypto.Name,
                            MarketCapRank = resultCrypto.MarketCapRank,
                            Price = resultPrice.Prices[id]["sek"].Value<int?>()

                        };

                        CryptoRepository cryptoRepo = new(_dbContext);
                        await cryptoRepo.Add(crypto);
                        await cryptoRepo.SaveChanges();

                    }

                    return resultCrypto;
                }
            }
            catch
            {
				
			}


			throw new HttpRequestException();
        }
    }
}
