﻿using System.ComponentModel.DataAnnotations;

namespace CinemaWorld.Areas.Identity.Pages.Account.InputModels
{
    public class LoginInputModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)] 
        
        public string Password { get; set; }

        [Display(Name="Remember me?")]
        public bool RememberMe { get; set; }    
    }
}
