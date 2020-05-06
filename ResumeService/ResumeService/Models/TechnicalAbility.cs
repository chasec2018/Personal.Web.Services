using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ResumeService.Models
{
    public class TechnicalAbility
    {
        public string Summary { get; set; }

        [JsonPropertyName("Programming Languages")]
        public Dictionary<string,string> ProgrammingLanguages { get; set; }

        [JsonPropertyName("Scripting Languages")]
        public Dictionary<string,string> ScriptingLanguages { get; set; }

        [JsonPropertyName("Database Management")]
        public Dictionary<string, string> DatabaseManagement { get; set; }

        [JsonPropertyName("Cloud Services")]
        public Dictionary<string, string> CloudServices { get; set; }

        [JsonPropertyName("Reporting Tools")]
        public Dictionary<string, string> ReportingTools { get; set; }

        [JsonPropertyName("ETL Tools")]
        public Dictionary<string, string> EtlTools { get; set; }

        public Dictionary<string, string> Architectures { get; set; }

        [JsonPropertyName("Design Patterns")]
        public Dictionary<string, string> DesignPatterns { get; set; }

        public Dictionary<string, string> Networking { get; set; }

        [JsonPropertyName("Other")]
        public Dictionary<string,string> Other { get; set; }

    }
}
