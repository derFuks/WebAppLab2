using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebAppLab2.Models;

namespace WebAppLab2.Pages
{
    public class ListModel : PageModel
    {
        public List<Product> Products { get; set; } = new();

        public void OnGet()
        {
            if (TempData.ContainsKey("Products"))
            {
                var json = TempData["Products"] as string;
                Products = JsonConvert.DeserializeObject<List<Product>>(json) ?? new();
                TempData["Products"] = json; // сохранить, чтобы не исчезло
            }
        }
    }
}
