using System.Web.Optimization;

namespace TenFor10.Infographic
{
	public static class BundleConfig
	{ 
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new StyleBundle("~/content/css").Include("~/assets/styles/less.css")
				.Include("~/assets/styles/normalize.css")
				.Include("~/assets/styles/main.css"));

			bundles.Add(new StyleBundle("~/content/admincss").Include("~/assets/styles/admin.css"));
			
			bundles.Add(new ScriptBundle("~/bundles/main")
				.Include("~/assets/scripts/main.js"));

			bundles.Add(new ScriptBundle("~/bundles/js")
				            .Include("~/assets/scripts/plugins/jquery-*")
							.Include("~/assets/scripts/plugins/jquery.*"));

		}
	}
}