﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ResumeService.Pages
{
    [Authorize]
    public class DemosModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}