using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ZGZY.IDAL
{
   public   interface IMenuButton
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
       int AddMenuButton(ZGZY.Model.MenuButton model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
       bool UpdateMenuButton(ZGZY.Model.MenuButton model);
        /// <summary>
        /// 删除数据
        /// </summary>
       bool DeleteMenuButton(int MenuId, int ButtonId);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
       ZGZY.Model.MenuButton GetMenuButtonModel(int MenuId, int ButtonId);
        /// <summary>
        /// 获得数据列表
        /// </summary>
       DataSet GetMenuButtonList(string strWhere);
    }
}
