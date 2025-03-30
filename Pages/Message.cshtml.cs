using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppLab2.Pages
{
    public class MessageModel : PageModel
    {
        public string? Message { get; set; }

        public void OnGet()
        {
            Message = TempData["Message"] as string;
        }
    }
}
