using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TokenAuthAspcore.Data {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public async void EnsureSeedData(UserManager<ApplicationUser> userMgr, RoleManager<IdentityRole> roleMgr)
        {
            if (!await userMgr.Users.AnyAsync(u => u.UserName == "admin@test.com"))
            {
                // Add 'admin' role
                var adminRole = await roleMgr.FindByNameAsync("admin");
                if (adminRole == null)
                {
                    adminRole = new IdentityRole("admin");
                    await roleMgr.CreateAsync(adminRole);
                }

                // create admin user
                var adminUser = new ApplicationUser();
                adminUser.UserName = "admin@test.com";
                adminUser.Email = "admin@test.com";

                await userMgr.CreateAsync(adminUser, "Test1234%");

                await userMgr.SetLockoutEnabledAsync(adminUser, false);
                await userMgr.AddToRoleAsync(adminUser, "admin");
            }
        }
    }
}
