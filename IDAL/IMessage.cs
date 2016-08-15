using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ZGZY.IDAL
{
  public   interface IMessage
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
      int  AddMessage(ZGZY.Model.Message model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
      bool UpdateMessage(ZGZY.Model.Message model);
        /// <summary>
        /// 删除数据
        /// </summary>
      bool DeleteMessage(string id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
      ZGZY.Model.Message GetMessageModel(string id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
      DataSet GetMessageList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
      DataSet GetMessageList(int Top, string strWhere, string filedOrder);

      /// <summary>
      /// 批量删除
      /// </summary>
      /// <param name="ids"></param>
      /// <returns></returns>
      int DeleteRange(string ids);
      

    }
}
