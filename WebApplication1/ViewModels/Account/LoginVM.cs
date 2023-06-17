﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels.Account
{
    public class LoginVM
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
