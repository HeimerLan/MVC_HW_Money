using System.Web;
using System.Web.Mvc;

namespace prjMVC_HW_Money
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
