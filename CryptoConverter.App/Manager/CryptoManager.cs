using CryptoConverter.Data.Models;
using CryptoConverterApp.ApiCaller;

namespace CryptoConverterApp.Manager
{
    public class CryptoManager
    {
        public CryptoModel ApiModelToDbModel(CryptoRoot cRoot)
        {
            CryptoApiCaller caller = new CryptoApiCaller();


            CryptoModel cryptoModel = new CryptoModel()
            {
                Id = cRoot.Id,
                Symbol = cRoot.Symbol,
                Name = cRoot.Name,
                Description = cRoot.Description,
                Price = ApiModelToDbModel(caller.GetPriceFromId(cRoot.Id).Result)
            };



            return cryptoModel;
        }

        public PriceDbModel ApiModelToDbModel(PriceModel price)
        {
            if (price != null)
            {
                PriceDbModel priceDb = new PriceDbModel()
                {
                    Price = price.Sek
                };

                return priceDb;
            }

            throw new HttpRequestException();

        }
    }
}
