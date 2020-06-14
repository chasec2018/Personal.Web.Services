using System;
using System.IO;
using ResumeService.Services;
using System.Collections.Generic;
using ResumeService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ResumeService.Pages
{
    public class ExperienceModel : PageModel
    {
        private readonly JsonDataHandler JsonHandler;
        private readonly IWebHostEnvironment WebHostEnvironment;
        private readonly ILogger<ExperienceModel> Logger;

        public ExperienceModel(JsonDataHandler jsonHandler, IWebHostEnvironment webHostEnvironment, ILogger<ExperienceModel> logger)
        {
            JsonHandler = jsonHandler;
            WebHostEnvironment = webHostEnvironment;
            Logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public List<ExperienceHistory> Experiences { get; set; } = new List<ExperienceHistory>();

        [BindProperty(SupportsGet = true)]
        public string CSharpCode { get; set; } = @"
    public class ExperienceModel : PageModel
    {
        private readonly JsonAppDataHandler JsonHandler;
        private readonly IWebHostEnvironment WebHostEnvironment;
        private readonly ILogger<ExperienceModel> Logger;

        public ExperienceModel(JsonAppDataHandler jsonHandler, IWebHostEnvironment webHostEnvironment, ILogger<ExperienceModel> logger)
        {
            JsonHandler = jsonHandler;
            WebHostEnvironment = webHostEnvironment;
            Logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public List<ExperienceHistory> Experiences { get; set; } = new List<ExperienceHistory>();

        public bool SetLeftSide(int Counter)
        {
            string[] rightValues = { '0', '2', '4', '6', '8' };

            foreach(var value in rightValues)
            {
                if (Counter.ToString().Substring(Counter.ToString().Length - 1, 1).Equals(value))
                    return true;
            }
            return false;
        }

        public void OnGet()
        {
            try
            {
                Experiences.AddRange(JsonHandler.ReturnGenericJsonObject<List<ExperienceHistory>>(
                    Path.Combine(WebHostEnvironment.WebRootPath, 'json\\experience-history.json')));
            }
            catch (Exception exception)
            {
                Logger.LogError('An Error occurred parsing Experience History Json File.', exception);
            }
        }
    }
";

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
            try
            {
                Experiences.AddRange(JsonHandler.ReturnGenericJsonObject<List<ExperienceHistory>>(
                    Path.Combine(WebHostEnvironment.WebRootPath, "json\\experience-history.json")));
            }
            catch(Exception exception)
            {
                Logger.LogError("An Error occurred parsing Experience History Json File.", exception);
            }
        }
    }
}