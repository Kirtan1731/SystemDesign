using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using webApis.DAL.Models;

namespace webApis.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Roles
            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole
                {
                    Id = "d0b1a7a9-2b3b-4c57-b3e8-123456789987",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    Description = "Administrator role"
                },
                new ApplicationRole
                {
                    Id = "ab12cd34-ef56-7890-abcd-123456789123",
                    Name = "User",
                    NormalizedName = "USER",
                    Description = "Regular user role"
                }
            );
        }
    }
}
