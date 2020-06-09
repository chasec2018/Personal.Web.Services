using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ResumeService.Models
{
    public class ProjectHistory
    {
        [JsonPropertyName("Accordian ID")]
        public int AccordianID { get; set; }

        [JsonPropertyName("Header ID")]
        public int HeaderID { get; set; }

        [JsonPropertyName("Project Title")]
        public string ProjectTitle { get; set; }
        public string Timeline { get; set; }
        public string Company { get; set; }
        public string Overview { get; set; }
        public List<string> Technology { get; set; }
        public List<string> Languages { get; set; }
    }
}
