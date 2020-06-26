using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResumeService.Areas.Identity.EntityModels;

namespace ResumeService.Areas.Identity.Data
{
    public class ResumeServiceContext : IdentityDbContext<ResumeServiceUsers, ResumeServiceRoles, Guid>
    {

        public ResumeServiceContext(DbContextOptions<ResumeServiceContext> options) : base(options)
        {
            
        }


        public DbSet<ResumeServiceVisitors> ResumeServiceVisitors { get; set; }


        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.HasDefaultSchema("Access");

            Builder.Entity<ResumeServiceVisitors>()
                .Property(p => p.CreationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");


            base.OnModelCreating(Builder);

        }
    }
}
