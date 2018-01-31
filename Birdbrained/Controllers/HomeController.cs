using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Birdbrained.Controllers
{
	public class HomeController : Controller
	{
		// home page
		public ActionResult Index()
		{
			return View();
		}

		// about page
		public ActionResult About()
		{
			return View();
		}

		// contact page
		public ActionResult Contact()
		{
			return View();
		}
	}
}