using System;
using System.IO;
using ResumeService.Models;
using ResumeService.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ResumeService.Pages
{
    public class RepositoryModel : PageModel
    {
        public JsonAppDataService RepoSolutionsAppData;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public RepositoryModel(JsonAppDataService JsonAppData, IWebHostEnvironment WHostEnvironment)
        {
            RepoSolutionsAppData = JsonAppData;
            WebHostEnvironment = WHostEnvironment;
        }

        [BindProperty(SupportsGet = true)]
        public List<RepositorySolutions> Solutions { get; set; }

        public void OnGet()
        {
            string path = Path.Combine(WebHostEnvironment.ContentRootPath, "Data\\repository-solutions.json");
            Solutions = RepoSolutionsAppData.ReturnGenericJsonObject<List<RepositorySolutions>>(path);

        }
    }
}