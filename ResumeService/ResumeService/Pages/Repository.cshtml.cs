using System;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ResumeService.EntryModels;
using ResumeService.Services;


namespace ResumeService.Pages
{
    public class RepositoryModel : PageModel
    {
        private readonly JsonDataHandler JsonHandler;
        private readonly IWebHostEnvironment WebHostEnvironment;
        private readonly ILogger<RepositoryModel> Logger;

        public RepositoryModel(JsonDataHandler jsonHandler, IWebHostEnvironment webHostEnvironment, ILogger<RepositoryModel> logger)
        {
            JsonHandler = jsonHandler;
            WebHostEnvironment = webHostEnvironment;
            Logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public GithubRepositoryEntries Repositories { get; set; } = new GithubRepositoryEntries();

        [BindProperty(SupportsGet = true)]
        public string CSharpCode { get; set; } = @"
    public class RepositoryModel : PageModel
    {
        private readonly JsonAppDataHandler JsonHandler;
        private readonly IWebHostEnvironment WebHostEnvironment;
        private readonly ILogger<RepositoryModel> Logger;

        public RepositoryModel(JsonAppDataHandler jsonHandler, IWebHostEnvironment webHostEnvironment, ILogger<RepositoryModel> logger)
        {
            JsonHandler = jsonHandler;
            WebHostEnvironment = webHostEnvironment;
            Logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public GithubRepos Repositories { get; set; } = new GithubRepos();

        public async Task OnGetAsync()
        {
            try
            {
                using (HttpClient Client = new HttpClient())
                {

                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue('application/vnd.github.v3+json'));
                    Client.DefaultRequestHeaders.Add('User-Agent', '.NET Foundation Repository Reporter');

                    List<GithubRepo> Repos = JsonSerializer.Deserialize<List<GithubRepo>>(
                        await Client.GetStringAsync('https://api.github.com/users/chasec2018/repos'));

                    Repositories.AddGithubRepos(Repos.ToArray());

                            }
            }
            catch(Exception exception)
            {
                Logger.LogError('An Error occurred while trying to request Repository list from Gihub API', exception);
            }
        }
    }
";

        public async Task OnGetAsync()
        {
            try
            {
                using (HttpClient Client = new HttpClient())
                {
                    // Step 01 : Clear Default Request Headers from HttpRequestMessage and add Required Github Headers
                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                    Client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                    // Step 02 : Request Results from URI Query
                    string JsonResults = await Client.GetStringAsync("https://api.github.com/users/chasec2018/repos");

                    // Step 03 : Deserialize Results into 
                    List<GithubRepositoryEntry> Repos = JsonSerializer.Deserialize<List<GithubRepositoryEntry>>(JsonResults);

                    // Step 04 : Add Deserialize Results to GithubRepositoryEntries IEnumerable
                    Repositories.AddGithubRepos(Repos.ToArray());

                }
            }
            catch(Exception exception)
            {
                Logger.LogError("An Error occurred while trying to request Repository list from Gihub API", exception);
            }
        }
    }
}