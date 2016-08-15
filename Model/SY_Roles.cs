using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZGZY.Model
{
    /// <summary>
    /// 系统角色
    /// </summary>
    public class SY_Roles
    {
        /// <summary>
        /// 标识号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Limn { get; set; }

        /// <summary>
        /// 有效状态
        /// </summary>
        public int ValidState { get; set; }

        /// <summary>
        /// 创建人员
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
