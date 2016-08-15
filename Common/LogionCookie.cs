using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace ZGZY.Common
{
    public class LogionCookie
    {
        /// <summary>
        /// 写入Cookie
        /// </summary>
        /// <param name="strName">键</param>
        /// <param name="strVal">值</param>
        public static void WriteMutualCookie(string id, string nickname)
        {
            System.Web.HttpCookie newcookie = new HttpCookie("voucher");
            
           
            newcookie.Values["identHED"] = Utils.EncryptionParameter(id);
            newcookie.Values["nickname"] = HttpContext.Current.Server.UrlEncode(nickname);
            newcookie.Expires = DateTime.Now.AddMinutes(Convert.ToDouble(ConfigurationManager.AppSettings["LoginEffectiveHours"]));
            //newcookie.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.AppendCookie(newcookie);
            
            
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DeleteVouCookie()
        {
            System.Web.HttpCookie newcookie = new HttpCookie("voucher");
            newcookie.Expires = DateTime.Now.AddDays(-10);
            HttpContext.Current.Response.AppendCookie(newcookie);
        }

        /// <summary>
        /// 读取Cookie
        /// </summary>
        /// <param name="strName">属性值</param>
        /// <returns></returns>
        public static string GetMutualCookie(string strName)
        {
            string strVal = "";
            if (HttpContext.Current.Request.Cookies["voucher"] != null)
            {
                strVal = Utils.DecryptionParameter(HttpContext.Current.Request.Cookies["voucher"][strName]);
            }
            return strVal;

        }
        /// <summary>
        /// 判断用户是否登陆
        /// </summary>
        /// <returns></returns>
        public static bool CheckLogin()
        {
            return GetUserId() != null;
        }
        /// <summary>
        /// 获得用户登陆id
        /// </summary>
        /// <returns></returns>
        public static string GetUserId()
        {
            return GetMutualCookie("identHED");
        }
        /// <summary>
        /// 获得用户登陆名
        /// </summary>
        /// <returns></returns>
        public static string GetUserName()
        {
            return GetMutualCookie("nickname");
        }




    }
}
