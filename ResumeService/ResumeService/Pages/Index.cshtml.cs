using System;
using System.IO;
using System.Threading.Tasks;
using ResumeService.Models;
using ResumeService.Services;
using ResumeService.Properties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using ResumeService.Areas.Identity.Data;
using ResumeService.Areas.Identity.EntityModels;


namespace ResumeService.Pages
{
    public class IndexModel : PageModel
    {
        private readonly JsonDataHandler JsonHandler;
        private readonly IWebHostEnvironment WebHostEnvironment;
        private readonly ILogger<IndexModel> Logger;
        private readonly ResumeServiceContext Context;

        public IndexModel(JsonDataHandler jsonHandler, ResumeServiceContext context, IWebHostEnvironment webHostEnvironment, ILogger<IndexModel> logger)
        {
            JsonHandler = jsonHandler;
            WebHostEnvironment = webHostEnvironment;
            Logger = logger;
            Context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string ProfileImage { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public TechnicalAbility TechnicalAbilities { get; set; } = new TechnicalAbility();

        [BindProperty(SupportsGet = true)]
        public string CSharpCode { get; set; } = @"
    public class IndexModel : PageModel
    {
        
        private readonly JsonAppDataHandler JsonHandler;
        private readonly IWebHostEnvironment WebHostEnvironment;
        private readonly ILogger<IndexModel> Logger;

        public IndexModel(JsonAppDataHandler jsonHandler, IWebHostEnvironment webHostEnvironment, ILogger<IndexModel> logger)
        {
            JsonHandler = jsonHandler;
            WebHostEnvironment = webHostEnvironment;
            Logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public string ProfileImage { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public TechnicalAbility TechnicalAbilities { get; set; } = new TechnicalAbility();


        public void OnGet()
        {
            try
            {
                ProfileImage = String.Format('data:image/gif;base64,{0}', Convert.ToBase64String(Resources.ProfileImage));

                TechnicalAbilities = JsonHandler.ReturnGenericJsonObject<TechnicalAbility>(
                    Path.Combine(WebHostEnvironment.WebRootPath, 'json\\technical-ability.json'));
            }
            catch(Exception exception)
            {
                Logger.LogError('An Error occurred while try to render Index Page', exception);
            }
        }
    }
";

        public async Task OnGetAsync()
        {
            try
            {
                ProfileImage = String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(Resources.ProfileImage));

                TechnicalAbilities = JsonHandler.ReturnGenericJsonObject<TechnicalAbility>(
                    Path.Combine(WebHostEnvironment.WebRootPath, "json\\technical-ability.json"));


                ResumeServiceVisitors UniqueVisitor = new ResumeServiceVisitors();
                UniqueVisitor.IdentityName = HttpContext.User.Identity.Name;
                UniqueVisitor.IdentityAuthenticated = HttpContext.User.Identity.IsAuthenticated;
                UniqueVisitor.IdentityAuthenticationType = HttpContext.User.Identity.AuthenticationType;
                UniqueVisitor.RemoteIP = HttpContext.Connection.RemoteIpAddress.ToString();
                UniqueVisitor.RemotePort = HttpContext.Connection.RemotePort;


                await Context.AddAsync(UniqueVisitor);
                await Context.SaveChangesAsync();                
            }
            catch(Exception exception)
            {
                Logger.LogError("An Error occurred while try to render Index Page", exception);
            }
        }
    }
}
