using System;
using System.IO;
using ResumeService.Models;
using ResumeService.Services;
using ResumeService.Properties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;

namespace ResumeService.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> Logger;
        private JsonAppDataService TechnicalAbilityAppData;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public IndexModel(ILogger<IndexModel> logger, JsonAppDataService JsonAppData, IWebHostEnvironment WHostEnvironment)
        {
            Logger = logger;
            TechnicalAbilityAppData = JsonAppData;
            WebHostEnvironment = WHostEnvironment;
        }


        [BindProperty(SupportsGet = true)]
        public int YearsTraining
        {
            get
            {
                return DateTime.Now.Year - 2016;
            }
        }

        [BindProperty(SupportsGet = true)]
        public string ProfileImage { get; set; }

        [BindProperty(SupportsGet = true)]
        public TechnicalAbility TechnicalAbilities { get; set; }
        

        public void OnGet() // No Need for Async Operations
        {
            // get path for Json File in Root Directory
            string path = Path.Combine(WebHostEnvironment.ContentRootPath, "Data\\technical-ability.json");

            // Convert Binary Images into Base 64 string 
            string base64 = Convert.ToBase64String(Resources.ProfileImage);

            // Set Profile with converted string
            ProfileImage = String.Format("data:image/gif;base64,{0}", base64);

            // Deserialize Json Data into Object and Set Property
            TechnicalAbilities =TechnicalAbilityAppData.ReturnGenericJsonObject<TechnicalAbility>(path);
           
        }
    }
}
