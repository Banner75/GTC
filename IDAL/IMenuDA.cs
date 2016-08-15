using System.Collections.Generic;
using System.Data;
using ZGZY.Model;

namespace ZGZY.IDAL
{
    /// <summary>
    /// 菜单接口（不同的数据库访问类实现接口达到多数据库的支持）
    /// </summary>
    public interface IMenuDA
    {
        #region 交易平台

        /// <summary>
        /// 读取交易平台菜单
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        List<SY_Menus> GetTradeMenus(int group);

        #endregion

        #region 新加代码

        /// <summary>
        /// 获取到主页菜单
        /// </summary>
        /// <param name="role"></param>
        /// <param name="group"></param>
        /// <param name="isTop"></param>
        /// <returns></returns>
        List<SY_Menus> GetHomeMenus(int role, int group, bool isTop);

        #endregion
    }
}
