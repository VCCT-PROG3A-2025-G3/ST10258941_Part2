using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Agri_Energy_Connect.Pages
{
    public static class InMemoryUserStore
    {
        public static Dictionary<string, string> Users = new Dictionary<string, string>(); // email -> password
        public static Dictionary<string, List<Product>> UserProducts = new Dictionary<string, List<Product>>();
        public static Dictionary<string, bool> IsFarmer = new Dictionary<string, bool>(); // email -> isFarmer

    }

    public class Product
    {
        public string PostedBy { get; set; } // Add this line

        public string ProductName { get; set; }
        public string Category { get; set; }
        public DateTime ProductionDate { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string? ImageFileName { get; set; }
    }
}
