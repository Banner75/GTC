using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZGZY.Model
{
    /// <summary>
    /// 交易平台注册帐号
    /// </summary>
    public class TP_Trade_Accounts
    {
        /// <summary>
        /// 注册帐号(电子邮件为标识)
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 登录口令
        /// </summary>
        public string Passwords { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 帐号昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 注册状态
        /// </summary>
        public int RegisterState { get; set; }

        /// <summary>
        /// 注册日期
        /// </summary>
        public int RegisterDate { get; set; }
    }
}
