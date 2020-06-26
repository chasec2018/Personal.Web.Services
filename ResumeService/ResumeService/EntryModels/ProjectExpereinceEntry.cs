using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ResumeService.EntryModels
{
    public class ProjectExpereinceEntry
    {
        [Required]
        [JsonPropertyName("Object ID")]
        public int EntryID { get; set; }

        [JsonPropertyName("Project Title")]
        public string ProjectTitle { get; set; }

        [JsonPropertyName("Start Month")] 
        public string StartMonth { get; set; }

        [JsonPropertyName("Start Year")]
        public int StartYear { get; set; }

        [JsonPropertyName("End Month")]
        public string EndMonth { get; set; }

        [JsonPropertyName("End Year")]
        public int EndYear { get; set; }

        public string Company { get; set; }
        public string Overview { get; set; }
        public List<string> Technology { get; set; }
        public List<string> Languages { get; set; }
    }
}
