using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZGZY.Model
{
    /// <summary>
    /// 帮助中心(主表)
    /// </summary>
    public class BS_Helps
    {
        /// <summary>
        /// 标识号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string KeyWord { get; set; }

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
