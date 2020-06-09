﻿using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace ResumeService.Areas.Identity.Data
{
    public class ResumeServiceRoles : IdentityRole<Guid>
    {

        public string Description { get; set; }

    }
}
