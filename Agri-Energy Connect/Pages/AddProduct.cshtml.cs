using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Agri_Energy_Connect;

namespace Agri_Energy_Connect.Pages
{
    public class AddProductModel : PageModel
    {
        [BindProperty]
        public string ProductName { get; set; }

        [BindProperty]
        public string Category { get; set; }

        [BindProperty]
        public DateTime ProductionDate { get; set; }

        [BindProperty]
        public decimal Price { get; set; }

        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        public IFormFile ProductImage { get; set; }

        public List<Product> UserProducts { get; set; } = new();

        public IActionResult OnGet()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToPage("/Register");
            }

            if (InMemoryUserStore.UserProducts.TryGetValue(email, out var products))
            {
                UserProducts = products;
            }

            if (!InMemoryUserStore.IsFarmer.TryGetValue(email, out bool isFarmer) || !isFarmer)
            {
                // Redirect if user is not a farmer
                return RedirectToPage("/BecomeFarmer");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            var email = HttpContext.Session.GetString("UserEmail");

            if (string.IsNullOrEmpty(email))
            {
                return RedirectToPage("/Register");
            }

            if (!InMemoryUserStore.IsFarmer.TryGetValue(email, out bool isFarmer) || !isFarmer)
            {
                return RedirectToPage("/BecomeFarmer");
            }

            var product = new Product
            {
                ProductName = ProductName,
                Category = Category,
                ProductionDate = ProductionDate,
                Price = Price,
                Description = Description,
                ImageFileName = ProductImage?.FileName ?? "ComingSoon.jpg",
                PostedBy = email // Save user info here
            };

            if (!InMemoryUserStore.UserProducts.ContainsKey(email))
            {
                InMemoryUserStore.UserProducts[email] = new List<Product>();
            }

            InMemoryUserStore.UserProducts[email].Add(product);

            return RedirectToPage();
        }

    }
}
