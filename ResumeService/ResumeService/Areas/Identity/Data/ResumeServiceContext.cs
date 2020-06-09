using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResumeService.Areas.Identity;
using ResumeService.Areas.Identity.Data;

namespace ResumeService.Data
{
    public class ResumeServiceContext : IdentityDbContext<ResumeServiceUsers, ResumeServiceRoles, Guid>
    {

        public ResumeServiceContext(DbContextOptions<ResumeServiceContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
