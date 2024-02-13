using CryptoConverter.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CryptoConverterUi.Pages
{
    public class IndexModel : PageModel
    {
        public CryptoModel crypto { get; set; }
        private List<string> cryptos { get; set; } = new List<string>()
        {
            "bitcoin",
            "ethereum",
            "tether",
            "ripple",
            "solana"
        };


        public void OnGet()
        {
            CryptoApiCaller caller = new();

            crypto = caller.GetCrypto();
        }
    }
}
