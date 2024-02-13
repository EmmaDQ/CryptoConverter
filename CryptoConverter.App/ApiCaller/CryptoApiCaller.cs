using CryptoConverter.App.Manager;
using CryptoConverter.Data.Models;
using Newtonsoft.Json;
using static CryptoConverter.Data.Models.ApiModel;


namespace CryptoConverter.App.ApiCaller
{
    public class CryptoApiCaller
    {
        //länk

        public async Task<CryptoModel> GetCrypto(string id)
        {
            //Get first (or random) 10 cryptos

            HttpClient clientCrypto = new HttpClient();
            clientCrypto.BaseAddress = new Uri("https://api.coingecko.com/api/v3/exchanges/");

            HttpResponseMessage responseCrypto = await clientCrypto.GetAsync(id.ToLower());

            if (responseCrypto.IsSuccessStatusCode)
            {
                string cryptoJson = await responseCrypto.Content.ReadAsStringAsync();

                CryptoRoot cryptoRoot = JsonConvert.DeserializeObject<CryptoRoot>(cryptoJson);

                if (cryptoRoot != null)
                {
                    CryptoManager manager = new CryptoManager();

                    CryptoModel cryptoDbModel = new CryptoModel();
                    cryptoDbModel = manager.ApiModelToDbModel(cryptoRoot);

                    return cryptoDbModel;
                }

                throw new JsonException();

            }

            throw new HttpRequestException();
        }

        public async Task<PriceModel> GetPriceFromId(string id)
        {
            HttpClient clientPrice = new HttpClient();
            clientPrice.BaseAddress = new Uri("https://api.coingecko.com/api/v3/simple/");

            string getPrice = $"price?ids={id}&vs_currencies=sek";
            HttpResponseMessage responsePrice = await clientPrice.GetAsync(getPrice.ToLower());

            if (responsePrice.IsSuccessStatusCode)
            {
                string priceJson = await responsePrice.Content.ReadAsStringAsync();

                PriceRoot? priceRoot = JsonConvert.DeserializeObject<PriceRoot>(priceJson);
                PriceModel priceModel = new PriceModel()
                {
                    Sek = priceRoot.Price.Sek,
                };

                if (priceRoot != null)
                {
                    priceModel.Sek = priceRoot.Price.Sek;

                    return priceModel;
                }

                throw new JsonException();

            }


            throw new HttpRequestException();

        }
    }
}
