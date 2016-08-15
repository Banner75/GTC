using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZGZY.Model
{
    /// <summary>
    /// 系统用户
    /// </summary>
    public class SY_Users
    {
        /// <summary>
        /// 登录帐号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string TrulyName { get; set; }

        /// <summary>
        /// 用户是否启用。0：未启用；1：启用；2：冻结；3：注销；
        /// </summary>
        public int IsUsing { get; set; }

        /// <summary>
        /// 用户是否已修改密码。0：未修改；1:已修改；
        /// </summary>
        public int IsModifyPW { get; set; }

       /// <summary>
        /// 备注说明
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建人员
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public int LastUpdatedBy { get; set; }

        /// <summary>
        /// 最后修改日期
        /// </summary>
        public int LastUpdateDate { get; set; }
    }
}
