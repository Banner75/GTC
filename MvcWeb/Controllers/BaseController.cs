using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZGZY.Model;

namespace MvcWeb.Controllers
{
    /// <summary>
    /// 功能说明：检查登录情况
    /// 创建人员：DeanWinchester
    /// 创建时间：2016/07/01
    /// </summary>
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            string Userid = ZGZY.Common.LogionCookie.GetUserId();
            if (string.IsNullOrEmpty(Userid.Trim()))
            {
                filterContext.Result = new ContentResult { Content = "<script>location.href='/Home/Login'</script>" };//功能权限弹出提示框
            }else{
            
                BS_Customers data = new ZGZY.BLL.CustomerBL().GetCustomerByID(Userid);
                if (data.State > 1)
                {
                    filterContext.Result = new ContentResult { Content = "<script>alert('此账号失效，不可登录');location.href='/Home/Login'</script>" };//功能权限弹出提示框
                }
                if (data == null)
                {
                    ZGZY.Common.LogionCookie.DeleteVouCookie();
                    filterContext.Result = new ContentResult { Content = "<script>location.href='/Home/Login'</script>" };//功能权限弹出提示框
                }
                ZGZY.Common.LogionCookie.WriteMutualCookie(data.Login_Account, data.Nick_Name);
            }
        }
        /// <summary>
        /// 返回JSON字符串
        /// </summary>
        /// <param name="state">状态码</param>
        /// <param name="message">信息</param>
        /// <returns></returns>
        public JsonResult JsonValues(int state, string message)
        {
            JsonResult JSON = new JsonResult();
            JSON.Data = new { status = state, msg = message };
            return JSON;// Json("{\"status\":" + state + ",\"msg\":\"" + message + "\"}");
        }
    }
}
