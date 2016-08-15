using MvcWeb;
using System;
using System.Web.Mvc;
namespace System.Web.Mvc
{
    /// <summary>
    /// 分页Html扩展
    /// </summary>
    public static class PagerHtmlExtension
    {
        /// <summary>
        /// 前台分页
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        /// <param name="pageModel">分页对象</param>
        /// <returns></returns>
        public static string WebPager(this HtmlHelper helper, PageModel pageModel)
        {
            //return String.Format(@"<span id=""{0}"">{1}</span>",1,1);
            return new WebPager(pageModel, helper.ViewContext).ToString();
        }
    }
}
