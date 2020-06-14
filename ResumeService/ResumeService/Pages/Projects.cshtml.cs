using System;
using System.IO;
using ResumeService.Services;
using ResumeService.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace ResumeService.Pages
{
    public class ProjectsModel : PageModel
    {
        private readonly JsonDataHandler JsonHandler;
        private readonly IWebHostEnvironment WebHostEnvironment;
        private readonly ILogger<ProjectsModel> Logger;

        public ProjectsModel(JsonDataHandler jsonHandler, IWebHostEnvironment webHostEnvironment, ILogger<ProjectsModel> logger)
        {
            JsonHandler = jsonHandler;
            WebHostEnvironment = webHostEnvironment;
            Logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public List<ProjectHistory> ProjHistory { get; set; } = new List<ProjectHistory>();

        [BindProperty(SupportsGet = true)]
        public string CSharpCode { get; private set; } = @"
public class ProjectsModel : PageModel
    {
        private readonly JsonAppDataHandler JsonHandler;
        private readonly IWebHostEnvironment WebHostEnvironment;
        private readonly ILogger<ProjectsModel> Logger;

        public ProjectsModel(JsonAppDataHandler jsonHandler, IWebHostEnvironment webHostEnvironment, ILogger<ProjectsModel> logger)
        {
            JsonHandler = jsonHandler;
            WebHostEnvironment = webHostEnvironment;
            Logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public List<ProjectHistory> ProjHistory { get; set; } = new List<ProjectHistory>();

        public void OnGet()
        {
            try
            {
                ProjHistory.AddRange(JsonHandler.ReturnGenericJsonObject<List<ProjectHistory>>(
                    Path.Combine(WebHostEnvironment.WebRootPath, 'json\\project-history.json')));
            }
            catch(Exception exception)
            {
                Logger.LogError('An Error occurred while parsing Project History Json File.', exception);
            }
        }
    }

";

        public void OnGet()
        {
            try
            {
                ProjHistory.AddRange(JsonHandler.ReturnGenericJsonObject<List<ProjectHistory>>(
                    Path.Combine(WebHostEnvironment.WebRootPath, "json\\project-history.json")));
            }
            catch(Exception exception)
            {
                Logger.LogError("An Error occurred while parsing Project History Json File.", exception);
            }
        }
    }
}