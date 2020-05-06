using System;
using System.IO;
using ResumeService.Services;
using ResumeService.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;

namespace ResumeService.Pages
{
    public class ProjectsModel : PageModel
    {
        public JsonAppDataService ProjectHistoryAppData;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public ProjectsModel(JsonAppDataService JsonAppData, IWebHostEnvironment WHostEnvironment)
        {
            ProjectHistoryAppData = JsonAppData;
            WebHostEnvironment = WHostEnvironment;
        }

        [BindProperty(SupportsGet = true)]
        public List<ProjectHistory> ProjHistory { get; set; }


        public void OnGet()
        {
            string path = Path.Combine(WebHostEnvironment.ContentRootPath, "Data\\project-history.json");
            ProjHistory = ProjectHistoryAppData.ReturnGenericJsonObject<List<ProjectHistory>>(path);

        }
    }
}