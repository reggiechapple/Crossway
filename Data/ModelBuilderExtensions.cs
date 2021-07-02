using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Crossways.Data.Identity;

namespace Crossways.Data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedAdmin(this ModelBuilder builder) 
        {
            string ADMIN_ROLEID = Guid.NewGuid().ToString();
            string ADMIN_USERID = Guid.NewGuid().ToString();

             var appUser = new ApplicationUser 
            {
                Id = ADMIN_USERID,
                FullName = "Super User",
                Email = "sudo@local.com",
                UserName = "sudo",
                NormalizedUserName = "SUDO",
                NormalizedEmail = "SUDO@LOCAL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true
            };

            var hasher = new PasswordHasher<ApplicationUser>();
            appUser.PasswordHash = hasher.HashPassword(appUser, "P@ss1234");

            builder.Entity<ApplicationUser>().HasData(appUser);
            
            builder.Entity<ApplicationRole>().HasData(new List<ApplicationRole>
            {
                new ApplicationRole {
                    Id = ADMIN_ROLEID,
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new ApplicationRole {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Member",
                    NormalizedName = "MEMBER"
                },
                new ApplicationRole {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Publisher",
                    NormalizedName = "PUBLISHER"
                },
            });

            builder.Entity<ApplicationUserRole>().HasData(new ApplicationUserRole
            {
                RoleId = ADMIN_ROLEID,
                UserId = ADMIN_USERID
            });
        }
    }
}