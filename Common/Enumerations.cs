using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ZGZY.Common
{
    /// <summary>
    /// 菜单分组
    /// </summary>
    public enum Menu_Groups
    {
        [Description("未分组")]
        nmUnSet = 0,

        [Description("会员管理组")]
        nmCustomer = 1,

        [Description("交易平台组")]
        nmTradeFlat = 2 
    }

    /// <summary>
    /// 修改密码类别
    /// </summary>
    public enum Account_Pwd_Kind
    {
        [Description("查询密码")]
        nmQueryPwd = 1,

        [Description("交易密码")]
        nmPayPwd = 2
    }

    /// <summary>
    /// 资讯管理: 公司公告/行业新闻
    /// </summary>
    public enum Information_Notice
    {
        [Description("未设置")]
        nmNoSet = 0,

        [Description("公司公告")]
        nmNotice = 1,

        [Description("行业新闻")]
        nmTrade_News = 2,

        [Description("文件列表")]
        nmFile_List = 3,

        [Description("系统消息")]
        nmSystem_message = 4,

        [Description("我的留言")]
        nmMy_Leave_Word = 5
    }

    
}
