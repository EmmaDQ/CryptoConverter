using CryptoConverter.App.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CryptoConverterUi.Pages.Crypto
{
    public class homeModel : PageModel
    {

        public List<string> Cryptos { get; set; } = new();

        public void OnGet()
        {
            Cryptos = Enum.GetNames(typeof(CryptoNames)).ToList();  
        }
    }
}
