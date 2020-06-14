using System;
using System.ComponentModel.DataAnnotations;


namespace ResumeService.Areas.Identity.InputModels
{
    public class InputProfileModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Company { get; set; }

        public string JobTitle { get; set; }
    }
}
