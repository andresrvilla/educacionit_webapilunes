using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instituto.API.Seguridad
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        private const string ADMIN_ROLE = "29bdb4b9-5078-42fd-8f03-c618915ff74a";

        private const string ADMIN_USER = "7b7e2a00-73d4-414b-ad37-525c5977019c";

        private const string USER_ROLE = "5ee41b3a-fa37-4dd4-9906-0efdbe609326";

        private const string USER_USER = "b47d8fa8-3c10-4f81-8812-85300259f829";

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // En este metodo podria customizar todo lo que tiene que ver con nombres de tablas, namespace y columnas
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ADMIN_ROLE,
                    Name= Instituto.API.Seguridad.UserRoles.Admin,
                    NormalizedName = Instituto.API.Seguridad.UserRoles.Admin.ToUpper()
                },
                new IdentityRole
                {
                    Id = USER_ROLE,
                    Name = Instituto.API.Seguridad.UserRoles.User,
                    NormalizedName = Instituto.API.Seguridad.UserRoles.User.ToUpper()
                }
                );

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id= USER_USER,
                    UserName="user",
                    NormalizedUserName="USER",
                    PasswordHash = hasher.HashPassword(null,"User123!")
                },
                new ApplicationUser
                {
                    Id = ADMIN_USER,
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = hasher.HashPassword(null, "Admin123!")
                }
                );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = ADMIN_ROLE,
                    UserId = ADMIN_USER
                },
                new IdentityUserRole<string>()
                {
                    RoleId = USER_ROLE,
                    UserId = USER_USER
                }
                );
        }
    }
}
