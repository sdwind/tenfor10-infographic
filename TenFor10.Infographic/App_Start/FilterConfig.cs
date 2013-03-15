using System.Web;
using System.Web.Mvc;

namespace TenFor10.Infographic
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}