using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResumeService.Areas.Identity.Data;
using ResumeService.Areas.Identity.EntityModels;

namespace ResumeService.Pages
{
    [Authorize(Roles ="Administrator")]
    public class AdminPortalModel : PageModel
    {
        private readonly ResumeServiceContext Context;


        public AdminPortalModel(ResumeServiceContext context)
        {
            Context = context;
        }

        [BindProperty(SupportsGet = true)]
        public ResumeServiceUsers[] Users { get; set; }


        public async Task OnGetAsync()
        {

            Users = Context.Users.ToArray<ResumeServiceUsers>();

        }
    }
}