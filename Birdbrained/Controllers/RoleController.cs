using Birdbrained.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Birdbrained.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
			ApplicationDbContext context = new ApplicationDbContext();
			// read user role and send them to appropriate view
			if (!User.Identity.IsAuthenticated || !isAdminUser())
			{
				return RedirectToAction("Index", "Home");
			}
			var Roles = context.Roles.ToList();
            return View(Roles);
        }

		// determine if user is admin
		public bool isAdminUser()
		{
			if (User.Identity.IsAuthenticated)
			{
				var user = User.Identity;
				ApplicationDbContext context = new ApplicationDbContext();
				var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
				var s = UserManager.GetRoles(user.GetUserId());
				if (s[0].ToString() == "Admin")
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			return false;
		}
	}
}