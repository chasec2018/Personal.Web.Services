using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Runtime.CompilerServices;

namespace ResumeService.Areas.Identity.EntityModels
{
    public class ResumeServiceUsers : IdentityUser<Guid>
    {
        
        [Column(TypeName = "Varchar(255)")]
        public string FirstName { get; set; }

        [Column(TypeName = "Varchar(255)")]
        public string LastName { get; set; }

        [Column(TypeName ="Date")]
        public DateTime Birthday { get; set; }

        [Column(TypeName = "Varchar(255)")]
        public string Company { get; set; }

        [Column(TypeName = "Varchar(255)")]
        public string JobTitle { get; set; }
    }
}
