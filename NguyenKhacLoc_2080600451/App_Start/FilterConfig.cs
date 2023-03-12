using System.Web;
using System.Web.Mvc;

namespace NguyenKhacLoc_2080600451
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
