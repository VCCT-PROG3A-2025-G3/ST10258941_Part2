using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agri_Energy_Connect.Pages
{
    public class HubModel : PageModel
    {
        private readonly AppDbContext _context;

        public HubModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Content { get; set; }

        public List<Post> Posts { get; set; }

        public void OnGet()
        {
            // Fetch all posts from DB, newest first
            Posts = _context.Posts
                .OrderByDescending(p => p.PostedAt)
                .ToList();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Content))
            {
                return Page();
            }

            var post = new Post
            {
                Title = Title,
                Content = Content,
                Author = HttpContext.Session.GetString("UserEmail") ?? "Guest",
                PostedAt = DateTime.Now
            };

            _context.Posts.Add(post);
            _context.SaveChanges();

            return RedirectToPage();
        }
    }
}
