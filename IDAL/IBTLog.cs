using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ZGZY.IDAL
{
   public  interface IBTLog
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
       int AddBTLog(ZGZY.Model.BTLog model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
       bool UpdateBTLog(ZGZY.Model.BTLog model);
        /// <summary>
        /// 删除数据
        /// </summary>
       bool DeleteBTLog(int ID);
       bool DeleteBTLogList(string IDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
       ZGZY.Model.BTLog GetBTLogModel(int ID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
       DataSet GetBTLogList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
       DataSet GetBTLogList(int Top, string strWhere, string filedOrder);
    }
}
