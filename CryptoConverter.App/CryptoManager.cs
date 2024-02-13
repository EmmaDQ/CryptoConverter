using CryptoConverter.Data.Models;
using static CryptoConverter.Data.Models.ApiModel;

namespace CryptoConverter.App
{
    internal class CryptoManager
    {
        public CryptoModel ApiModelToDbModel(CryptoRoot cRoot)
        {



            CryptoModel cryptoModel = new CryptoModel()
            {
                Id = cRoot.Id,
                Symbol = cRoot.Symbol,
                Name = cRoot.Name,
                Description = cRoot.Description,
                Price = GetPriceFromId(cRoot.Id)
            };



            return cryptoModel;
        }
    }
}
