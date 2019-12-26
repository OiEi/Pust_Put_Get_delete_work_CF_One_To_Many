using System.Web;
using System.Web.Mvc;

namespace CRUD_One_To_Many
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
