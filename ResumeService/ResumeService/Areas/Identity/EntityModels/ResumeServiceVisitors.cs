using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResumeService.Areas.Identity.EntityModels
{
    [Table("ResumeServiceVisitors", Schema = "Insight")]
    public class ResumeServiceVisitors
    {
        [Key]
        public int TransactionID { get; set; }
        public string? IdentityName { get; set; }
        public bool? IdentityAuthenticated { get; set; } = false;
        public string? IdentityAuthenticationType { get; set; }
        public string? RemoteIP { get; set; }
        public int RemotePort { get; set; } = 0;

        public string? ClientCertificateThumbprint { get; set; }
        public string? ClientCertificateSubject { get; set; }
        public string? ClientCertificateIssuer { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.Now.Date;
    }
}
