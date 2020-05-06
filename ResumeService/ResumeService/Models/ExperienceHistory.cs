using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeService.Models
{
    public class ExperienceHistory
    {
        public int ObjectID { get; set; }
        public string StartMonth { get; set; }
        public int StartYear { get; set; }
        public string EndMonth { get; set; }
        public int EndYear { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string EmploymentType { get; set; }
        public List<string> Tasks { get; set; }
    }
}
