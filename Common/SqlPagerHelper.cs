using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ZGZY.Common
{
    /// <summary>
    /// SQL分页帮助类
    /// </summary>
    public class SqlPagerHelper
    {
        /// <summary>
        /// 获取分页数据（单表分页）
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="columns">要取的列名（逗号分开）</param>
        /// <param name="order">排序</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="where">查询条件</param>
        /// <param name="totalCount">总记录数</param>
        public static DataTable GetPager(string tableName, string columns, string order, int pageSize, int pageIndex, string where, out int totalCount)
        {
            SqlParameter[] paras = { 
                                   new SqlParameter("@tablename",SqlDbType.VarChar,100),
                                   new SqlParameter("@columns",SqlDbType.VarChar,500),
                                   new SqlParameter("@order",SqlDbType.VarChar,100),
                                   new SqlParameter("@pageSize",SqlDbType.Int),
                                   new SqlParameter("@pageIndex",SqlDbType.Int),
                                   new SqlParameter("@where",SqlDbType.VarChar,2000),
                                   new SqlParameter("@totalCount",SqlDbType.Int)
                                   };
            paras[0].Value = tableName;
            paras[1].Value = columns;
            paras[2].Value = order;
            paras[3].Value = pageSize;
            paras[4].Value = pageIndex;
            paras[5].Value = where;
            paras[6].Direction = ParameterDirection.Output;   //输出参数

            DataTable dt = ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, "sp_Pager", paras);
            totalCount = Convert.ToInt32(paras[6].Value);   //赋值输出参数，即当前记录总数
            return dt;
        } 
        /// <summary>
        /// 输出分页样式
        /// </summary>
        /// <param name="total">总记录数</param>
        /// <param name="per">每页记录数</param>
        /// <param name="page">当前页数</param>
        /// <param name="query_string">>Url参数</param>
        /// <returns></returns>
        public static string  pagination(int total, int per, int page, string query_string)
        {
            int allpage = 0;
            int next = 0;
            int pre = 0;
            int startcount = 0;
            int endcount = 0;
            string pagestr = "";

            if (page < 1) { page = 1; }
            //计算总页数
            if (per != 0)
            {
                allpage = (total / per);
                allpage = ((total % per) != 0 ? allpage + 1 : allpage);
                allpage = (allpage == 0 ? 1 : allpage);
            }
            next = page + 1;
            pre = page - 1;
            startcount = (page + 5) > allpage ? allpage - 9 : page - 4;//中间页起始序号
            //中间页终止序号
            endcount = page < 5 ? 10 : page + 5;
            if (startcount < 1) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
            if (allpage < endcount) { endcount = allpage; }//页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内
            pagestr = "共" + allpage + "页&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";

            pagestr += page > 1 ? "<a href=\"" + query_string + "?page=1\">首页</a>&nbsp;&nbsp;<a href=\"" + query_string + "?page=" + pre + "\">上一页</a>" : "首页 上一页";
            //中间页处理，这个增加时间复杂度，减小空间复杂度
            for (int i = startcount; i <= endcount; i++)
            {
                pagestr += page == i ? "&nbsp;&nbsp;<font color=\"#ff0000\">" + i + "</font>" : "&nbsp;&nbsp;<a href=\"" + query_string + "?page=" + i + "\">" + i + "</a>";
            }
            pagestr += page != allpage ? "&nbsp;&nbsp;<a href=\"" + query_string + "?page=" + next + "\">下一页</a>&nbsp;&nbsp;<a href=\"" + query_string + "?page=" + allpage + "\">末页</a>" : " 下一页 末页";

            return pagestr;
        }


        /// <summary>
        /// 输出分页样式
        /// </summary>
        /// <param name="total">总记录数</param>
        /// <param name="per">每页记录数</param>
        /// <param name="page">当前页数</param>
        /// <param name="query_string">ajax-js</param>
        /// <returns></returns>
        public static string pagination_js(int total, int per, int page, string query_string)
        {
            int allpage = 0;
            int next = 0;
            int pre = 0;
            int startcount = 0;
            int endcount = 0;
            string pagestr = "";

            if (page < 1) { page = 1; }
            //计算总页数
            if (per != 0)
            {
                allpage = (total / per);
                allpage = ((total % per) != 0 ? allpage + 1 : allpage);
                allpage = (allpage == 0 ? 1 : allpage);
            }
            next = page + 1;
            pre = page - 1;
            startcount = (page + 5) > allpage ? allpage - 9 : page - 4;//中间页起始序号
            //中间页终止序号
            endcount = page < 5 ? 10 : page + 5;
            if (startcount < 1) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
            if (allpage < endcount) { endcount = allpage; }//页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内
            pagestr = "共" + allpage + "页&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";

            pagestr += page > 1 ? "<a href=\"#\" onclick=\"" + query_string + "('1')\">首页</a>&nbsp;&nbsp;<a href=\"#\" onclick=\"" + query_string + "('" + pre + "')\">上一页</a>" : "首页 上一页";
            //中间页处理，这个增加时间复杂度，减小空间复杂度
            for (int i = startcount; i <= endcount; i++)
            {
                pagestr += page == i ? "&nbsp;&nbsp;<font color=\"#ff0000\">" + i + "</font>" : "&nbsp;&nbsp;<a href=\"#\" onclick=\"" + query_string + "('" + i + "')\">" + i + "</a>";
            }
            pagestr += page != allpage ? "&nbsp;&nbsp;<a href=\"#\" onclick=\"" + query_string + "('" + next + "')\">下一页</a>&nbsp;&nbsp;<a href=\"#\" onclick=\"" + query_string + "('"+ allpage +" ')\">末页</a>" : " 下一页 末页";
            return pagestr;
        }

    }
}
