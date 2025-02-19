﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using POS1.Controllers;
using System.ComponentModel.DataAnnotations;

// User model for demonstration purposes
namespace POS1.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string FullName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public required string Email { get; set; }

         //   [Required(ErrorMessage = "Password is required.")]
        //   [StringLength(100, MinimumLength = 14, ErrorMessage = "Password must be between 14 and 100 characters.")]
        //   [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,}",
        //ErrorMessage = "Password must contain at least one number, one uppercase letter, and one lowercase letter.")]
       // public string? Password { get; set; } // User's password (hashed)
        [Required, MinLength(14)] //should be 14 and with combination
        [StringLength(255)]
        public required string Password { get; set; } // Store hashed passwords
    }
}

    /*public int Id { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; } // Store hashed passwords
    public required string Role { get; set; }
    public required string Status { get; set; }
    public required bool IsActive { get; set; } */

