using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ResumeService.EntryModels
{
    public class WorkExperienceEntry
    {
        [JsonPropertyName("Object ID")]
        public int ObjectID { get; set; }

        [JsonPropertyName("Start Month")]
        public string StartMonth { get; set; }

        [JsonPropertyName("Start Year")]
        public int StartYear { get; set; }

        [JsonPropertyName("End Month")]
        public string EndMonth { get; set; }

        [JsonPropertyName("End Year")]
        public int EndYear { get; set; }

        public string Company { get; set; }

        public string Title { get; set; }

        [JsonPropertyName("Employment Type")]
        public string EmploymentType { get; set; }

        public List<string> Tasks { get; set; } = new List<string>();
    }
}
