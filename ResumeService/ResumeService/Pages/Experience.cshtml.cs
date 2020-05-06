using System;
using System.IO;
using ResumeService.Services;
using System.Collections.Generic;
using ResumeService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ResumeService.Pages
{
    public class ExperienceModel : PageModel
    {

        public JsonAppDataService ExperienceHistoryAppData;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public ExperienceModel(JsonAppDataService JsonAppData, IWebHostEnvironment WHostEnvironment)
        {
            ExperienceHistoryAppData = JsonAppData;
            WebHostEnvironment = WHostEnvironment;
        }

        [BindProperty(SupportsGet = true)]
        public List<ExperienceHistory> Experiences { get; set; }

        public bool SetLeftSide(int Counter)
        {
            string[] rightValues = { "0", "2", "4", "6", "8" };
            foreach(var value in rightValues)
            {
                if (Counter.ToString().Substring(Counter.ToString().Length - 1, 1).Equals(value))
                    return true;
            }
            return false;
        }

        public void OnGet()
        {
            string path = Path.Combine(WebHostEnvironment.ContentRootPath, "Data", "experience-history.json");
            Experiences = ExperienceHistoryAppData.ReturnGenericJsonObject<List<ExperienceHistory>>(path);
        }
    }
}