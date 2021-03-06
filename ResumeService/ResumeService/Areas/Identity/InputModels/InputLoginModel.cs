﻿using System.ComponentModel.DataAnnotations;


namespace ResumeService.Areas.Identity.InputModels
{
    public class InputLoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
