using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWeb.Controllers
{
    /// <summary>
    /// 功能说明： 麦格币管理
    /// 创建人员： 林红刚
    /// 创建日期： 2016/06/20
    /// 重制版人员：DeanWinchester
    /// </summary>
    public class MacCoinController : Controller
    {
        #region 钱包地址

        /// <summary>
        /// 页面启动
        /// </summary>
        /// <returns></returns>
        private ActionResult WalletAddr()
        {
            return View();
        }

        #endregion

        #region 转入卖格币钱包

        /// <summary>
        /// 界面启动
        /// </summary>
        /// <returns></returns>
        private ActionResult MoveToWallet()
        {
            return View();
        }

        #endregion
    }
}
