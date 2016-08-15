using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ZGZY.IDAL
{
  public   interface IUserType
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
      bool ExistsUserType(string where );
        /// <summary>
        /// 增加一条数据
        /// </summary>
      int  AddUserType(ZGZY.Model.BS_Customer_Type model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
      bool UpdateUserType(ZGZY.Model.BS_Customer_Type model);
        /// <summary>
        /// 删除数据
        /// </summary>
      bool DeleteUserType(string Id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
      ZGZY.Model.BS_Customer_Type GetUserTypeModel(string Id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
      DataSet GetUserTypeList(string strWhere);
    }
}
