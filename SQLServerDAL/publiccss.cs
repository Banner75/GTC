using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZGZY.SQLServerDAL
{
    public class publiccss : ZGZY.IDAL.Ipublic
    {
        /// <summary>
        /// 执行sql事物
        /// </summary>
        /// <returns></returns>
       public  int ExecuteSqlTran(List<String> SQLStringList)
       {
           return ZGZY.Common.SqlHelper.ExecuteSqlTran(SQLStringList);
       }
    }
}
