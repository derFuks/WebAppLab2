using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebAppLab2.Models;

namespace WebAppLab2.Pages
{
    public class ProductModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; } = new Product();
        public string? Name { get; set; }

        [BindProperty]
        public decimal? Price { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            List<Product> products;
            
            if (TempData.ContainsKey("Products"))
            {
                var json = TempData["Products"] as string;
                products = JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>();
            }
            else
            {
                products = new List<Product>();
            }

            if (string.IsNullOrEmpty(Product.Name) || Product.Price == null || Product.Price < 0)
            {
                TempData["Message"] = "Введены некорректные данные.";
                return RedirectToPage("Message");
            }
            
            products.Add(new Product
            {
                Name = Product.Name,
                Price = Product.Price
            });

            TempData["Products"] = JsonConvert.SerializeObject(products);
            return RedirectToPage("List");

            
        }
    }
}