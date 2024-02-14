using CryptoConverter.Data.Database.Repositories;
using CryptoConverter.Data.Models;
using CryptoConverterApp.ApiCaller;
using CryptoConverterData.Database;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CryptoConverterUi.Pages.Crypto
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext dbContext;
        public CryptoModel? Crypto { get; set; }

        public DetailsModel(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task OnGet(string id)
        {
            CryptoRepository cryptoRepo = new(dbContext);
            CryptoApiCaller cryptoApiCaller = new CryptoApiCaller(dbContext);

            Crypto = await cryptoRepo.GetById(id.ToLower());

            if (Crypto == null)
            {
                await cryptoApiCaller.MakeCall(id.ToLower());
            }

            Crypto = await cryptoRepo.GetById(id.ToLower());
        }
    }
}
