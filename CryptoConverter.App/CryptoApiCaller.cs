using CryptoConverter.Data.Models;
using Newtonsoft.Json;
using static CryptoConverter.Data.Models.ApiModel;

namespace CryptoConverter.App
{
    public class CryptoApiCaller
    {
        //länk

        public async Task<CryptoModel> GetCrypto(string id)
        {
            //Get first (or random) 10 cryptos

            HttpClient clientCrypto = new HttpClient();
            clientCrypto.BaseAddress = new Uri("https://api.coingecko.com/api/v3/exchanges?per_page=1&page=1");

            HttpResponseMessage responseCrypto = await clientCrypto.GetAsync(id);

            if (responseCrypto.IsSuccessStatusCode)
            {
                string cryptoJson = await responseCrypto.Content.ReadAsStringAsync();

                CryptoRoot cryptoRoot = JsonConvert.DeserializeObject<CryptoRoot>(cryptoJson;

                if (cryptoRoot != null)
                {
                    CryptoModel cryptoDbModel = new CryptoModel().ApiModelToDbModel(cryptoRoot);
                    return cryptoDbModel;
                }

                throw new JsonException();

            }


        }

        public async Task<decimal>? GetPriceFromId(string id)
        {
            HttpClient clientPrice = new HttpClient();
            clientPrice.BaseAddress = new Uri("https://api.coingecko.com/api/v3/simple/price?ids=gate&vs_currencies=sek");

            HttpResponseMessage responsePrice = await clientPrice.GetAsync(id);

            if (responsePrice.IsSuccessStatusCode)
            {
                string priceJson = await responsePrice.Content.ReadAsStringAsync();

                PriceRoot? priceRoot = JsonConvert.DeserializeObject<CryptoRoot>(priceJson;
                PriceModel priceModel = new PriceModel()
                {
                    Sek = priceRoot.Price.Sek,
                };

                if (priceRoot != null)
                {
                    decimal price = priceModel.Sek;

                    return price;
                }

                throw new JsonException();

            }


            throw new HttpRequestException();

        }
    }
}
