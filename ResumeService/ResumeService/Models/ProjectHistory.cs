using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeService.Models
{
    public class ProjectHistory
    {
        public int AccordianID { get; set; }
        public int HeaderID { get; set; }
        public string ProjectTitle { get; set; }
        public string Timeline { get; set; }
        public string Company { get; set; }
        public string Overview { get; set; }
        public List<string> Technology { get; set; }
        public List<string> Languages { get; set; }
    }
}
