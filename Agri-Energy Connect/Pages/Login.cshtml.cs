using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Agri_Energy_Connect.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;

        public LoginModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Please enter both email and password.";
                return Page();
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == Email);

            if (user != null && user.Password == Password)
            {
                HttpContext.Session.SetString("UserEmail", user.Email);
                return RedirectToPage("/Index");
            }

            ErrorMessage = "Invalid email or password.";
            return Page();
        }
    }
}
