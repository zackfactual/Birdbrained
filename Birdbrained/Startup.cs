using Microsoft.Owin;
using Owin;
using Birdbrained.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartupAttribute(typeof(Birdbrained.Startup))]
namespace Birdbrained
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
			createRolesAndUsers();
        }

		// create default User roles and Admin user for login
		private void createRolesAndUsers()
		{
			ApplicationDbContext context = new ApplicationDbContext();

			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

			// in Startup, create first Admin Role and default Admin User
			if (!roleManager.RoleExists("Admin"))
			{
				// create Admin role
				var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
				role.Name = "Admin";
				roleManager.Create(role);

				// create Admin superuser to maintain site
				var user = new ApplicationUser();
				user.UserName = "zackfactual";
				user.Email = "zackfactual@gmail.com";

				string userPWD = "birdistheword";

				var chkUser = userManager.Create(user, userPWD);

				// add default User to Role Admin
				if (chkUser.Succeeded)
				{
					var result1 = userManager.AddToRole(user.Id, "Admin");
				}
			}

			if (!roleManager.RoleExists("Guest"))
			{
				var role = new IdentityRole();
				role.Name = "Guest";
				roleManager.Create(role);
			}
		}
    }
}
