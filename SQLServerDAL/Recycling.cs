/**  版本信息模板在安装目录下，可自行修改。
* tbRecycling.cs
*
* 功 能： N/A
* 类 名： tbRecycling
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/13 10:23:11   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZGZY.IDAL;
using ZGZY.Common;
namespace ZGZY.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:tbRecycling
    /// </summary>
    public partial class Recycling : IRecycling
    {
        public Recycling()
        { }
        #region  BasicMethod

        ///// <summary>
        ///// 是否存在该记录
        ///// </summary>
        //public bool Exists(string ID)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select count(1) from tbRecycling");
        //    strSql.Append(" where ID=@ID ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@ID", SqlDbType.VarChar,20)			};
        //    parameters[0].Value = ID;

        //    return ZGZY.Common.SqlHelper.Exists(strSql.ToString(), parameters);
        //}


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZGZY.Model.Recycling model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbRecycling(");
            strSql.Append("ID,UserID,ShowMoney,addtime,updatetime,state,transfernum,transfertime,rate)");
            strSql.Append(" values (");
            strSql.Append("@ID,@UserID,@ShowMoney,@addtime,@updatetime,@state,@transfernum,@transfertime,@rate)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,20),
					new SqlParameter("@UserID", SqlDbType.VarChar,20),
					new SqlParameter("@ShowMoney", SqlDbType.Decimal,9),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@updatetime", SqlDbType.DateTime),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@transfernum", SqlDbType.VarChar,50),
					new SqlParameter("@transfertime", SqlDbType.DateTime),
					new SqlParameter("@rate", SqlDbType.Decimal,9)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.ShowMoney;
            parameters[3].Value = model.addtime;
            parameters[4].Value = model.updatetime;
            parameters[5].Value = model.state;
            parameters[6].Value = model.transfernum;
            parameters[7].Value = model.transfertime;
            parameters[8].Value = model.rate;

            int rows = ZGZY.Common.SqlHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZGZY.Model.Recycling model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbRecycling set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("ShowMoney=@ShowMoney,");
            strSql.Append("addtime=@addtime,");
            strSql.Append("updatetime=@updatetime,");
            strSql.Append("state=@state,");
            strSql.Append("HandleAdminID=@HandleAdminID,");
            strSql.Append("TransferAdminID=@TransferAdminID,");
            strSql.Append("transfernum=@transfernum,");
            strSql.Append("transfertime=@transfertime,");
            strSql.Append("rate=@rate");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,20),
					new SqlParameter("@ShowMoney", SqlDbType.Decimal,9),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@updatetime", SqlDbType.DateTime),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@HandleAdminID", SqlDbType.Int,4),
					new SqlParameter("@TransferAdminID", SqlDbType.Int,4),
					new SqlParameter("@transfernum", SqlDbType.VarChar,50),
					new SqlParameter("@transfertime", SqlDbType.DateTime),
					new SqlParameter("@rate", SqlDbType.Decimal,9),
					new SqlParameter("@ID", SqlDbType.VarChar,20)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.ShowMoney;
            parameters[2].Value = model.addtime;
            parameters[3].Value = model.updatetime;
            parameters[4].Value = model.state;
            parameters[5].Value = model.HandleAdminID;
            parameters[6].Value = model.TransferAdminID;
            parameters[7].Value = model.transfernum;
            parameters[8].Value = model.transfertime;
            parameters[9].Value = model.rate;
            parameters[10].Value = model.ID;

            int rows = ZGZY.Common.SqlHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbRecycling ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,20)			};
            parameters[0].Value = ID;

            int rows = ZGZY.Common.SqlHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbRecycling ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = ZGZY.Common.SqlHelper.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZGZY.Model.Recycling GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from tbRecycling ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,20)			};
            parameters[0].Value = ID;

            ZGZY.Model.Recycling model = new ZGZY.Model.Recycling();
            DataSet ds = ZGZY.Common.SqlHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZGZY.Model.Recycling DataRowToModel(DataRow row)
        {
            ZGZY.Model.Recycling model = new ZGZY.Model.Recycling();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["UserID"] != null)
                {
                    model.UserID = row["UserID"].ToString();
                }
                if (row["ShowMoney"] != null && row["ShowMoney"].ToString() != "")
                {
                    model.ShowMoney = decimal.Parse(row["ShowMoney"].ToString());
                }
                if (row["addtime"] != null && row["addtime"].ToString() != "")
                {
                    model.addtime = DateTime.Parse(row["addtime"].ToString());
                }
                if (row["updatetime"] != null && row["updatetime"].ToString() != "")
                {
                    model.updatetime = DateTime.Parse(row["updatetime"].ToString());
                }
                if (row["state"] != null && row["state"].ToString() != "")
                {
                    model.state = int.Parse(row["state"].ToString());
                }
                if (row["HandleAdminID"] != null && row["HandleAdminID"].ToString() != "")
                {
                    model.HandleAdminID = int.Parse(row["HandleAdminID"].ToString());
                }
                if (row["TransferAdminID"] != null && row["TransferAdminID"].ToString() != "")
                {
                    model.TransferAdminID = int.Parse(row["TransferAdminID"].ToString());
                }
                if (row["transfernum"] != null)
                {
                    model.transfernum = row["transfernum"].ToString();
                }
                if (row["transfertime"] != null && row["transfertime"].ToString() != "")
                {
                    model.transfertime = DateTime.Parse(row["transfertime"].ToString());
                }
                if (row["rate"] != null && row["rate"].ToString() != "")
                {
                    model.rate = decimal.Parse(row["rate"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM tbRecycling ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return ZGZY.Common.SqlHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM tbRecycling ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return ZGZY.Common.SqlHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tbRecycling ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = ZGZY.Common.SqlHelper.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from tbRecycling T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return ZGZY.Common.SqlHelper.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "tbRecycling";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod

        /// <summary>
        /// 根据回收MRC币订单编号修改状态
        /// </summary>
        /// <param name="condition">修改的条件</param>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public int ChangeStateToRecycling(string condition, string id)
        {
            int result = 0;
            StringBuilder sql = new StringBuilder();
            sql.Append("update tbRecycling set " + condition + " where ID = '" + id + "'");
            result = SqlHelper.ExecuteSql(sql.ToString());
            return result;
        }

        /// <summary>
        /// 根据条件查询记录总数
        /// </summary>
        public int GetTotalCount(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from  tbRecycling as A  left join  tbUser as B on A.HandleAdminID = B.Id  left join  tbUser as C on A.TransferAdminID = C.Id ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" where " + where);
            }
            object count = ZGZY.Common.SqlHelper.ExecuteScalar(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
            return Convert.ToInt32(count);
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="strWhere">分页条件</param>
        /// <param name="orderBy">排序列</param>
        /// <param name="order">排序方式：asc、desc</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页大小</param>
        public DataTable GetPager(string strWhere, string orderBy, string order, int pageIndex, int pageSize)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from (");
            strSql.Append("select ROW_NUMBER() over (");
            if (!string.IsNullOrEmpty(orderBy) && !string.IsNullOrEmpty(order))
                strSql.Append("order by A." + orderBy + " " + order);
            else
                strSql.Append("order by A.ID asc");
            strSql.Append(") as Row,A.*,B.UserId as HandleAdminuserid,C.UserId as TransferAdminuserid from tbRecycling as A left join tbUser as B on A.HandleAdminID = B.Id  left join tbUser as C on A.TransferAdminID = C.Id");
            if (!string.IsNullOrEmpty(strWhere))
                strSql.Append(" where " + strWhere);
            strSql.Append(") TT");
            strSql.AppendFormat(" Where TT.Row between {0} and {1}", pageSize * (pageIndex - 1) + 1, pageSize * pageIndex);
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), null);
        }

    }
}

