using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TenFor10.Infographic.Models;

namespace TenFor10.Infographic.Controllers
{
    public class AdminController : Controller
    {
       
	  	[Authorize]
		[HttpGet]
        public ActionResult Index()
        {
            return View();
        }

		[Authorize]
		[HttpPost]
		public ActionResult Index(InfographicSettingsModel model)
		{
			return View(model);
		}

		[HttpGet]
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Login(LoginModel loginModel)
		{
			if (!ModelState.IsValid) return View(loginModel);

			if (loginModel.Password.ToLower() == System.Configuration.ConfigurationManager.AppSettings["AdminPassword"].ToLower())
			{  
				FormsAuthentication.SetAuthCookie("tenfor10admin", true);
				return RedirectToAction("Index");
			}

			ModelState.AddModelError("", "Login incorrect.");
			return View(loginModel);
		}

    }
}
