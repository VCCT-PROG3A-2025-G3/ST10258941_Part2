using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Agri_Energy_Connect.Pages
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }  // This must match what you want in DB
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsFarmer { get; set; } = false;
    }

}
