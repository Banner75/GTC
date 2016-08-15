using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ZGZY.SQLServerDAL
{
    /// <summary>
    /// 用户操作记录（SQL Server数据库实现）
    /// </summary>
    public class UserOperateLog : ZGZY.IDAL.IUserOperateLog
    {
        /// <summary>
        /// 写入操作日志
        /// </summary>
        public void InsertOperateLog(Model.UserOperateLog userOperateLog)
        {
            string sql = "insert into tbUserOperateLog(UserName,UserIp,OperateInfo,IfSuccess,Description,OperateDate) values (@UserName, @UserIp, @OperateInfo, @IfSuccess, @Description ,@OperateDate)";
            SqlParameter[] paras = { 
                                   new SqlParameter("@UserName",userOperateLog.UserName),
                                   new SqlParameter("@UserIp",userOperateLog.UserIp),
                                   new SqlParameter("@OperateInfo",userOperateLog.OperateInfo),
                                   new SqlParameter("@IfSuccess",userOperateLog.IfSuccess),
                                   new SqlParameter("@Description",userOperateLog.Description),
                                   new SqlParameter("@OperateDate",DateTime.Now)
                                   };
            ZGZY.Common.SqlHelper.ExecuteNonQuery(ZGZY.Common.SqlHelper.connStr, CommandType.Text, sql, paras);
        }
        /// <summary>
        /// 获取操作日志
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public DataTable GetUserOperateLogList(string strwhere)
        {
            string text = string.Empty;
            text = "select * from tbUserOperateLog";
            if (!string.IsNullOrWhiteSpace(strwhere))
            {
                text += string.Format(" where {0}", strwhere);
            }
            var datatable = ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, text);
            return datatable;
        }

    }
}
