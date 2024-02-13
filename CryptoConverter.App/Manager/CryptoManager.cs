using CryptoConverter.App.ApiCaller;
using CryptoConverter.Data.Models;
using static CryptoConverter.Data.Models.ApiModel;

namespace CryptoConverter.App.Manager
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
                Price = caller.GetPriceFromId(cRoot.Id).Result
            };



            return cryptoModel;
        }
    }
}
