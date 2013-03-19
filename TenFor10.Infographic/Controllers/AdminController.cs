using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using TenFor10.Infographic.Models;

namespace TenFor10.Infographic.Controllers
{
    public class AdminController : Controller
    {
       
	  	[Authorize]
		[HttpGet]
        public ActionResult Index()
	  	{
			var model = new InfographicSettingsModel();
			using (var fs = System.IO.File.Open(Server.MapPath("signups.txt"), FileMode.Open))
			{
				using (var sw = new StreamReader(fs))
				{
					using (var jw = new JsonTextReader(sw))
					{  
						var serializer = new JsonSerializer();
						model = serializer.Deserialize<InfographicSettingsModel>(jw);
					}
				}
			}
			return View(model ?? new InfographicSettingsModel());
        }

		[Authorize]
		[HttpPost]
		public ActionResult Index(InfographicSettingsModel model)
		{
			if (!ModelState.IsValid) return View(model);

			try
			{
				UpdateJson(model);
				model.Message = "Changes saved.";
			}
			catch (IOException ex)
			{
				//file is being used by another process, retry
				UpdateJson(model);
			}
			

			return View(model);
		}

		private void UpdateJson(InfographicSettingsModel model)
		{
			using (var fs = System.IO.File.Open(Server.MapPath("signups.txt"), FileMode.Truncate))
			using (var sw = new StreamWriter(fs))
			using (JsonWriter jw = new JsonTextWriter(sw))
			{
				jw.Formatting = Formatting.None;

				var serializer = new JsonSerializer();
				serializer.Serialize(jw, model);
			}
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
