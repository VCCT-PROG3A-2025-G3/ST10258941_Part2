using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Agri_Energy_Connect
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; } //  PRIMARY KEY

        [Required]
        public string ProductName { get; set; }

        public string Category { get; set; }

        public DateTime ProductionDate { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string PostedBy { get; set; } // User email


    }
}
