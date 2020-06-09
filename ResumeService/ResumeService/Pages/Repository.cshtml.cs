using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ResumeService.Models;
using ResumeService.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

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
        public GithubRepos Repositories { get; set; } = new GithubRepos();


        public async Task OnGet()
        {
            using(HttpClient Client = new HttpClient())
            {

                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                Client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                List<GithubRepo> Repos = JsonSerializer.Deserialize<List<GithubRepo>>(
                    await Client.GetStringAsync("https://api.github.com/users/chasec2018/repos"));

                Repositories.AddGithubRepos(Repos.ToArray());

            }
        }
    }
}