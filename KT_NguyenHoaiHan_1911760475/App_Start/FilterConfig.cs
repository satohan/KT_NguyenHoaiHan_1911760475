using System.Web;
using System.Web.Mvc;

namespace KT_NguyenHoaiHan_1911760475
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
