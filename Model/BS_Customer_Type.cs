using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZGZY.Model
{
  public  class BS_Customer_Type
    {
      /// <summary>
      /// 标识号
      /// </summary>
      public string ID { get;set;}

      /// <summary>
      /// 类型名称
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// 金我额
      /// </summary>
      public decimal Money { get; set; }

      /// <summary>
      /// 金币数量
      /// </summary>
      public int MachineNum { get; set; }
    }
}
