using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZGZY.Model
{
    /// <summary>
    /// 帮助中心(子表)
    /// </summary>
    public class BS_Help_Details
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 详细内容
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// 父帮助项
        /// </summary>
        public BS_Helps Parent { get; set; }

        /// <summary>
        /// 录入人员
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// 录入日期
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 最后更新人员
        /// </summary>
        public int LastUpdatedBy { get; set; }

        /// <summary>
        /// 最后更新日期
        /// </summary>
        public DateTime LastUpdatedDate { get; set; }
    }
}
