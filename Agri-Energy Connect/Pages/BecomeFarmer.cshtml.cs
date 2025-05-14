using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agri_Energy_Connect.Pages
{
    public class BecomeFarmerModel : PageModel
    {
        public IActionResult OnGet()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToPage("/Login");
            }

            if (InMemoryUserStore.IsFarmer.TryGetValue(email, out var isFarmer) && isFarmer)
            {
                // Already a farmer — redirect to another page (e.g., home)
                return RedirectToPage("/Index");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToPage("/Login");
            }

            InMemoryUserStore.IsFarmer[email] = true;
            return RedirectToPage("/AddProduct");
        }
    }
}
