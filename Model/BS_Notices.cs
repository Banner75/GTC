using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZGZY.Model
{
    /// <summary>
    /// 公司公告
    /// </summary>
    public class BS_Notices
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
        /// 内容
        /// </summary>
        public string Contents { get;set; }

        /// <summary>
        /// 输入人员
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 输入日期
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 最后修改人员
        /// </summary>
        public int LastUpdatedBy { get; set; }

        /// <summary>
        /// 最后更新日期
        /// </summary>
        public DateTime LastUpdatedDate { get; set; }


        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int Kind { get; set; }
    }
}
