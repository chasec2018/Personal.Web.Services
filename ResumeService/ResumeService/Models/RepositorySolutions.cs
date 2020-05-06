using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeService.Models
{
    public class RepositorySolutions
    {
        [JsonPropertyName("Solution ID")]
        public int ID { get; set; }

        [JsonPropertyName("Repository Title")]
        public string RepositoryTitle { get; set; }

        [JsonPropertyName("Repository Description")]
        public string RepositoryDesc { get; set; }

        [JsonPropertyName("Repository Link")]
        public string RespositoryLink { get; set; }

        [JsonPropertyName("Repository Git")]
        public string RepositoryGit { get; set; }
    }
}
