using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeService.Models
{
    public class EmailModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Affiliation { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
