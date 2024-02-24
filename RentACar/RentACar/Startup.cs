using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using RentACar.Models;

[assembly: OwinStartupAttribute(typeof(RentACar.Startup))]
namespace RentACar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRoleAndUsers();
        }

        private void createRoleAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = RoleName.Admin;
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "bojic";
                user.Email = "bojic@gmail.com";
                string userPWD = "Bojic-123";

                var chUser = userManager.Create(user, userPWD);
                if (chUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Admin");
                }
            }
            else if (!roleManager.RoleExists("Employee"))
            {
                var role = new IdentityRole();
                role.Name = RoleName.Employee;
                roleManager.Create(role);
            }
            else
            {
                var role = new IdentityRole();
                role.Name = RoleName.User;
                roleManager.Create(role);
            }
        }
    }
}
