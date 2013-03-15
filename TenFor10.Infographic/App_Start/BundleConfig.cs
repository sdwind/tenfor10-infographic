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

			bundles.Add(new ScriptBundle("~/bundles/main")
				.Include("~/assets/scripts/main.js")
				.Include("~/assets/scripts/dust-full-0.3.0.min.js"));
		
		}
	}
}