using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agri_Energy_Connect.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> ProductsToShow { get; set; } = new List<Product>();
        public string SelectedCategory { get; set; }
        public string SortOrder { get; set; } = "Newest"; // Default to "Newest"

        public List<string> PostedByUsers { get; set; } = new List<string>();
        public string SelectedPoster { get; set; }


        public List<string> Categories { get; set; } = new List<string>
        {
            "Irrigation", "Farming Tools", "Soil & Fertilizers", "Energy"
        };

        public IActionResult OnGet()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToPage("/Register");
            }

            // Add prototype sample products
            ProductsToShow.AddRange(new List<Product>
            {
                new Product
                {
                    ProductName = "Solar Water Pump",
                    Category = "Irrigation",
                    Price = 2499.99m,
                    Description = "Eco-friendly solar pump for small-scale farms.",
                    ImageFileName = "solar-pump.jpg",
                    ProductionDate = new DateTime(2023, 8, 5),
                    PostedBy = "test@gmail.com"
                },
                new Product
                {
                    ProductName = "Drip Irrigation Kit",
                    Category = "Irrigation",
                    Price = 899.00m,
                    Description = "Complete drip irrigation system covering up to 500m².",
                    ImageFileName = "drip-kit.jpg",
                    ProductionDate = new DateTime(2023, 7, 10),
                    PostedBy = "test@gmail.com"
                },
                new Product
                {
                    ProductName = "Organic Fertilizer (50kg)",
                    Category = "Soil & Fertilizers",
                    Price = 320.50m,
                    Description = "Boost your crop yield naturally with our organic blend.",
                    ImageFileName = "organic-fertilizer.jpg",
                    ProductionDate = new DateTime(2023, 5, 15),
                    PostedBy = "sample@agri.com"
                },
                new Product
                {
                    ProductName = "Wind Turbine (Mini)",
                    Category = "Energy",
                    Price = 7999.00m,
                    Description = "Small-scale wind turbine suitable for home or small farm energy needs.",
                    ImageFileName = "wind-turbine.jpg",
                    ProductionDate = new DateTime(2023, 9, 25),
                    PostedBy = "sample@agri.com"

                }
            });

            foreach (var userProductList in InMemoryUserStore.UserProducts.Values)
            {
                ProductsToShow.AddRange(userProductList);
            }

            // Filter products if a category is selected
            if (!string.IsNullOrEmpty(SelectedCategory))
            {
                ProductsToShow = ProductsToShow.Where(p => p.Category == SelectedCategory).ToList();
            }

            // Get distinct PostedBy users for the filter dropdown
            PostedByUsers = ProductsToShow
                .Where(p => !string.IsNullOrEmpty(p.PostedBy))
                .Select(p => p.PostedBy)
                .Distinct()
                .OrderBy(p => p)
                .ToList();

            if (!string.IsNullOrEmpty(SelectedPoster))
            {
                ProductsToShow = ProductsToShow.Where(p => p.PostedBy == SelectedPoster).ToList();
            }

            // Sort products based on the sort order
            if (SortOrder == "Newest")
            {
                ProductsToShow = ProductsToShow.OrderByDescending(p => p.ProductionDate).ToList();
            }
            else if (SortOrder == "Oldest")
            {
                ProductsToShow = ProductsToShow.OrderBy(p => p.ProductionDate).ToList();
            }

            return Page();
        }

        public IActionResult OnPostFilter(string selectedCategory)
        {
            SelectedCategory = selectedCategory;
            OnGet(); // Apply the filter and sorting when the form is submitted
            return Page();
        }

        public IActionResult OnPostSort(string sortOrder)
        {
            SortOrder = sortOrder;
            OnGet(); // Apply the sorting when the form is submitted
            return Page();
        }

        public IActionResult OnPostFilterByUser(string selectedPoster)
        {
            SelectedPoster = selectedPoster;
            OnGet(); // Apply filters
            return Page();
        }


        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Login");
        }
    }
}