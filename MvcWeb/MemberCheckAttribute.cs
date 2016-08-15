using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MvcWeb
{
    public class MemberCheckAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //判断是否登录或是否用权限，如果有那么就进行相应的操作，否则跳转到登录页或者授权页面
            //if (System.Web.HttpContext.Current.Session["userlist"] == null)
            //{
            //    filterContext.Result = new RedirectResult("/Home/Login");
            //}
            //base.OnActionExecuting(filterContext);
        }
    }
}