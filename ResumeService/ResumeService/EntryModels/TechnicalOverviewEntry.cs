using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ResumeService.EntryModels
{
    public class TechnicalOverviewEntry
    {
        public string Introduction { get; set; }

        public string Summary { get; set; }

        [JsonPropertyName("Programming Languages")]
        public List<Technologies> ProgrammingLanguages { get; set; }

        [JsonPropertyName("Scripting Languages")]
        public List<Technologies> ScriptingLanguages { get; set; }

        [JsonPropertyName("Database Management")]
        public List<Technologies> DatabaseManagement { get; set; }

        [JsonPropertyName("Cloud Services")]
        public List<Technologies> CloudServices { get; set; }

        [JsonPropertyName("Reporting Tools")]
        public List<Technologies> ReportingTools { get; set; }

        [JsonPropertyName("ETL Tools")]
        public List<Technologies> EtlTools { get; set; }

        public List<Technologies> Architectures { get; set; }

        [JsonPropertyName("Design Patterns")]
        public List<Technologies> DesignPatterns { get; set; }

        public List<Technologies> Networking { get; set; }

        [JsonPropertyName("Other")]
        public List<Technologies> Other { get; set; }

    }

    public class Technologies
    {
        public string Technology { get; set; }
        public string TechnologyUse { get; set; }
    }
}
