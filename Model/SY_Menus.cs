using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZGZY.Model
{
    /// <summary>
    /// 系统菜单
    /// </summary>
    public class SY_Menus
    {
        /// <summary>
        /// 菜单标识号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 菜单标题
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// 上级菜单
        /// </summary>
        public int ParentID { get; set; }

        /// <summary>
        /// 上级菜单名称
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// 上级显示标题
        /// </summary>
        public string ParentCaption { get; set; }

        /// <summary>
        /// 菜单组号
        /// </summary>
        public int Groups { get; set; }

        /// <summary>
        /// 组描述
        /// </summary>
        public string Groups_Linm { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 动作名称
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// 控制器名称
        /// </summary>
        public string ControlName { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 同级内顺序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 有效状态
        /// </summary>
        public int Valid_State { get; set; }

        /// <summary>
        /// 创建人员
        /// </summary>
        public int Created_By { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime Created_Date { get; set; }

        /// <summary>
        /// 备注说明
        /// </summary>
        public string Remark { get; set; }
    }
}
