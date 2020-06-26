using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeService.EntryModels;
using ResumeService.Areas.Identity.Data;
using ResumeService.Areas.Identity.EntityModels;
using ResumeService.Services;

using Microsoft.AspNetCore.Hosting;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ResumeService.Pages
{
    [Authorize(Roles ="Administrator")]
    public class AdminPortalModel : PageModel
    {
        private readonly ILogger<AdminPortalModel> Logger;
        private readonly IWebHostEnvironment WebHostEnvironment;
        private readonly ResumeServiceContext Context;
        private readonly JsonDataHandler JsonHandler;
        private readonly RoleManager<ResumeServiceRoles> RoleManager;


        public AdminPortalModel(ResumeServiceContext context, JsonDataHandler jsonHandler, IWebHostEnvironment webHostEnvironment, ILogger<AdminPortalModel> logger, RoleManager<ResumeServiceRoles> roleManager)
        {
            Context = context;
            JsonHandler = jsonHandler;
            WebHostEnvironment = webHostEnvironment;
            Logger = logger;
            RoleManager = roleManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public TechnicalOverviewEntry Overview { get; set; } = new TechnicalOverviewEntry();

        [BindProperty]
        public WorkExperienceEntry Experience { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<WorkExperienceEntry> Experiences { get; set; } = new List<WorkExperienceEntry>();

        [BindProperty]
        public ProjectExpereinceEntry Project { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<ProjectExpereinceEntry> Projects { get; set; } = new List<ProjectExpereinceEntry>();

        [BindProperty]
        public ResumeServiceRoles AppRole { get; set; }

        [BindProperty(SupportsGet = true)]
        public ResumeServiceRoles[] AppRoles { get; set; }

        [BindProperty]
        public ResumeServiceUsers AppUser { get; set; }

        [BindProperty(SupportsGet = true)]
        public ResumeServiceUsers[] AppUsers { get; set; }


        internal async Task LoadPageDataAsync()
        {
            try
            {
                AppUsers = await Context.Users.ToArrayAsync<ResumeServiceUsers>();

                AppRoles = await Context.Roles.ToArrayAsync<ResumeServiceRoles>();

                Overview = await JsonHandler.ReturnGenericJsonObjectAsync<TechnicalOverviewEntry>(
                    Path.Combine(WebHostEnvironment.WebRootPath, "json\\technical-ability.json"));

                Experiences = await JsonHandler.ReturnGenericJsonObjectAsync<List<WorkExperienceEntry>>(
                       Path.Combine(WebHostEnvironment.WebRootPath, "json\\experience-history.json"));

                Projects = await JsonHandler.ReturnGenericJsonObjectAsync<List<ProjectExpereinceEntry>>(
                       Path.Combine(WebHostEnvironment.WebRootPath, "json\\project-history.json"));
            }
            catch (Exception exception)
            {
                Logger.LogError(exception.Message, exception);
            }
        }


        public async Task OnGetAsync()
        {
            StatusMessage = null;

            await LoadPageDataAsync();
        }


        public async Task OnPostUpdateOverviewAsync()
        {

        }

        #region Experience Data Maintenance
        // [Finished]
        public async Task<IActionResult> OnPostUpdateExperienceHistoryAsync()
        {
            if (Experiences.Count == 1)
                Experience = Experiences[0];

            Experiences.Clear();

            await LoadPageDataAsync();

            if(Experiences.Count > 0)
            {
                for(int i = 0; i < Experiences.Count; i++)
                {
                    if (Experiences[i].ObjectID.Equals(Experience.ObjectID))
                    {
                        Experiences[i] = Experience;

                        await JsonHandler.AppendGenericJsonObjectAsync<List<WorkExperienceEntry>>(
                            Path.Combine(WebHostEnvironment.WebRootPath, "json\\experience-history.json"),
                            Experiences);

                        if (JsonHandler.ExceptionOccurred.Equals(true))
                        {
                            ModelState.AddModelError(string.Empty, "Was unable to change Experience History Data.");
                            Logger.LogError(JsonHandler.JsonHandlerException.Message, JsonHandler.JsonHandlerException);
                        }
                    }
                }
            }

            if (ModelState.IsValid)
                StatusMessage = "Successfully updated Experience History Data!";
            
            return RedirectToPage();
        }

        // [Finished]
        public async Task<IActionResult> OnPostDeleteExperienceEntryAsync()
        {
            await LoadPageDataAsync();

            if (Experience != null)
            {
                for(int i = 0;i< Experiences.Count; i++)
                {
                    if (Experiences[i].ObjectID == Experience.ObjectID)
                    {
                        Experiences.RemoveAt(i);
                        break;
                    }
                }

                await JsonHandler.AppendGenericJsonObjectAsync<List<WorkExperienceEntry>>(
                     Path.Combine(WebHostEnvironment.WebRootPath, "json\\experience-history.json"),
                     Experiences);

                if (JsonHandler.ExceptionOccurred.Equals(true))
                {
                    ModelState.AddModelError(string.Empty, "Was unable to change Experience History Data.");
                    Logger.LogError(JsonHandler.JsonHandlerException.Message, JsonHandler.JsonHandlerException);
                }
            }

            if (ModelState.IsValid)
                StatusMessage = "Successfully updated Experience History Data!";

            return Page();
        }

        // [Finished]
        public async Task<IActionResult> OnPostAddNewExperienceAsync()
        {
            await LoadPageDataAsync();

            if (Experience != null)
            {
                Experiences.Add(Experience);

                await JsonHandler.AppendGenericJsonObjectAsync<List<WorkExperienceEntry>>(
                     Path.Combine(WebHostEnvironment.WebRootPath, "json\\experience-history.json"),
                     Experiences);

                if (JsonHandler.ExceptionOccurred.Equals(true))
                {
                    ModelState.AddModelError(string.Empty, "Was unable to change Experience History Data.");
                    Logger.LogError(JsonHandler.JsonHandlerException.Message, JsonHandler.JsonHandlerException);
                }
            }

            await LoadPageDataAsync();

            if (ModelState.IsValid)
                StatusMessage = "Successfully updated Experience History Data!";

            return Page();
        }
        #endregion

        #region Project History Maintenance
        // [Finished]
        public async Task<IActionResult> OnPostUpdateProjectEntryAsync()
        {

            if (Projects.Count == 1)
                Project = Projects[0];

            Projects.Clear();

            await LoadPageDataAsync();

            if (Projects.Count > 0)
            {
                for(int i = 0; i < Projects.Count; i++)
                {
                    if (Projects[i].EntryID.Equals(Project.EntryID))
                    {
                        Projects[i] = Project;

                        await JsonHandler.AppendGenericJsonObjectAsync<List<ProjectExpereinceEntry>>(
                            Path.Combine(WebHostEnvironment.WebRootPath, "json\\project-history.json"),
                            Projects);

                        if (JsonHandler.ExceptionOccurred.Equals(true))
                        {
                            ModelState.AddModelError(string.Empty, "Was unable to change Project History Data.");
                            Logger.LogError(JsonHandler.JsonHandlerException.Message, JsonHandler.JsonHandlerException);
                        }

                        Project = new ProjectExpereinceEntry();
                        break;
                    }
                }
            }

            if (ModelState.IsValid)
                StatusMessage = "Successfully updated Project History Data!";

            return Page();

        }

        // [Finished]
        public async Task<IActionResult> OnPostDeleteProjectEntryAsync()
        {
            await LoadPageDataAsync();

            if (Project != null)
            {
                for (int i = 0; i < Projects.Count; i++)
                {
                    if (Projects[i].EntryID.Equals(Project.EntryID))
                    {
                        Projects.RemoveAt(i);
                        for (int a = 0; a < Projects.Count; a++)
                        {
                            Projects[a].EntryID = 1000 + a;
                        }
                        break;
                    }
                }

                await JsonHandler.AppendGenericJsonObjectAsync<List<ProjectExpereinceEntry>>(
                     Path.Combine(WebHostEnvironment.WebRootPath, "json\\project-history.json"),
                     Projects);

                if (JsonHandler.ExceptionOccurred.Equals(true))
                {
                    ModelState.AddModelError(string.Empty, "Was unable to change Project History Data.");
                    Logger.LogError(JsonHandler.JsonHandlerException.Message, JsonHandler.JsonHandlerException);
                }
            }

            if (ModelState.IsValid)
                StatusMessage = "Successfully updated Project History Data!";

            return Page();

        }

        // [Finished]
        public async Task<IActionResult> OnPostAddNewProjectEntryAsync()
        {
            await LoadPageDataAsync();

            if (Project != null)
            {
                Projects.Add(Project);

                await JsonHandler.AppendGenericJsonObjectAsync<List<ProjectExpereinceEntry>>(
                     Path.Combine(WebHostEnvironment.WebRootPath, "json\\project-history.json"),
                     Projects);

                if (JsonHandler.ExceptionOccurred.Equals(true))
                {
                    ModelState.AddModelError(string.Empty, "Was unable to change Project History Data.");
                    Logger.LogError(JsonHandler.JsonHandlerException.Message, JsonHandler.JsonHandlerException);
                }
            }

            await LoadPageDataAsync();

            if (ModelState.IsValid)
                StatusMessage = "Successfully updated Project History Data!";

            return Page();

        }
        #endregion

        #region Role Maintenance
        // [Finished]
        public async Task<IActionResult> OnPostAddDefinedRoleAsync()
        {
            try
            {
                IdentityResult Results = await RoleManager.CreateAsync(AppRole);

                if (!Results.Succeeded)
                {
                    foreach (var Error in Results.Errors)
                    {
                        ModelState.AddModelError(Error.Code, Error.Description);
                    }
                }
                else
                    StatusMessage = $"Role '{AppRole.Name}' was successfuly Created";

                await LoadPageDataAsync();

                return Page();
            }
            catch(Exception exception)
            {
                ModelState.AddModelError("Unknown Error", exception.Message);
                await LoadPageDataAsync();
                return Page();
            }
        }

        // [Finished]
        public async Task<IActionResult> OnPostDeleteDefinedRoleAsync()
        {
            try
            {
                IdentityResult Results = await RoleManager.DeleteAsync(
                    await RoleManager.FindByNameAsync(AppRole.Name));

                if (!Results.Succeeded)
                {
                    foreach(var Error in Results.Errors)
                    {
                        ModelState.AddModelError(Error.Code, Error.Description);
                    }
                }
                else
                    StatusMessage = $"Role '{AppRole.Name}' was successfuly Deleted";

                await LoadPageDataAsync();

                return Page();
            }
            catch(Exception exception)
            {
                ModelState.AddModelError("Unknown Error", exception.Message);
                await LoadPageDataAsync();
                return Page();
            }
        }

        // [Finished]
        public async Task<IActionResult> OnPostEditDefinedRoleAsync()
        {
            try
            {
                ResumeServiceRoles Role = await RoleManager.FindByIdAsync(AppRole.Id.ToString());

                if (Role == null)
                {
                    ModelState.AddModelError("Request Error", "Role could not be found");
                    await LoadPageDataAsync();
                    return Page();
                }

                if (Role.Name != AppRole.Name)
                {
                    IdentityResult Results = await RoleManager.SetRoleNameAsync(Role, AppRole.Name);

                    if (!Results.Succeeded)
                    {
                        foreach (var Error in Results.Errors)
                        {
                            ModelState.AddModelError(Error.Code, Error.Description);
                        }
                    }
                }

                Role.Description = AppRole.Description;

                IdentityResult DescriptionResults = await RoleManager.UpdateAsync(Role);


                if (!DescriptionResults.Succeeded)
                {
                    foreach (var Error in DescriptionResults.Errors)
                    {
                        ModelState.AddModelError(Error.Code, Error.Description);
                    }
                }
                else
                    StatusMessage = $"Role '{AppRole.Name}' was successfuly Edited";

                await LoadPageDataAsync();

                return Page();
            }
            catch(Exception exception)
            {
                ModelState.AddModelError("Unknown Error", exception.Message);
                await LoadPageDataAsync();
                return Page();
            }
            
        }

        #endregion 
    }
}