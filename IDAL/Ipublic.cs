using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZGZY.IDAL
{
   public interface Ipublic
    {

       /// <summary>
       /// 执行sql事物
       /// </summary>
       /// <returns></returns>
       int ExecuteSqlTran(List<String> SQLStringList);
    }
}
