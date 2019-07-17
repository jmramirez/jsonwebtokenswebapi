namespace JsonWebTokensWebApi.Migrations
{
    using JsonWebTokensWebApi.Infrastructure;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JsonWebTokensWebApi.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JsonWebTokensWebApi.Infrastructure.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "joshem31",
                Email = "joshem31@hotmail.com",
                EmailConfirmed = true,
                FirstName = "Jose",
                LastName = "Ramirez",
                Level = 1,
                JoinDate = DateTime.Now.AddYears(-3)
            };

            manager.Create(user, "Gam3cub#");

            //if (rolemanager.Roles.Count() == 0)
            //{
            //    rolemanager.Create(new IdentityRole { Name = "SuperAdmin" });
            //    rolemanager.Create(new IdentityRole { Name = "Admin" });
            //    rolemanager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByName("joshem31");
            //manager.AddToRoles(adminUser.Id, new string[] { "SuperAdmin", "Admin" });
        }
    }
}
