using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZGZY.Model;

namespace ZGZY.IDAL
{
    /// <summary>
    /// 功能说明：资讯管理
    /// 创建人员：林 红 刚
    /// 创建日期：2016/06/20
    /// </summary>
    public interface IInformationDA
    {
        #region 公司公告

        /// <summary>
        /// 读取公司公告信息
        /// </summary>
        /// <returns></returns>
        List<BS_Notices> GetNotices(int kind);

        /// <summary>
        /// 读取公司公告信息
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        List<BS_Notices> GetNotices(int kind, int nums);

        BS_Notices GetNoticeByID(int id);

        #endregion
    }
}
