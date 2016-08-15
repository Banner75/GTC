/**  版本信息模板在安装目录下，可自行修改。
* BS_Machine.cs
*
* 功 能： N/A
* 类 名： BS_Machine
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/2 10:45:26   N/A    初版
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
using System.Collections.Generic;

namespace ZGZY.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:BS_Machine
    /// </summary>
    public partial class BS_Machine : IBS_Machine
    {
        public BS_Machine()
        { }
        #region  BasicMethod




        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZGZY.Model.BS_Machine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BS_Machine(");
            strSql.Append("type,status,Login_Account,sum,OtherOREBonus,createrdate,start_run_time,end_run_time,count_time,today_count");
            strSql.Append(") values (");
            strSql.Append("@type,@status,@Login_Account,@sum,@OtherOREBonus,@createrdate,@start_run_time,@end_run_time,@count_time,@today_count");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@type", SqlDbType.Int,4) ,            
                        new SqlParameter("@status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Login_Account", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@sum", SqlDbType.Decimal) ,            
                        new SqlParameter("@OtherOREBonus", SqlDbType.Int,4) ,            
                        new SqlParameter("@createrdate", SqlDbType.DateTime) ,            
                        new SqlParameter("@start_run_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@end_run_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@count_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@today_count", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.type;
            parameters[1].Value = model.status;
            parameters[2].Value = model.Login_Account;
            parameters[3].Value = model.sum;
            parameters[4].Value = model.OtherOREBonus;
            parameters[5].Value = model.createrdate;
            parameters[6].Value = model.start_run_time;
            parameters[7].Value = model.end_run_time;
            parameters[8].Value = model.count_time;
            parameters[9].Value = model.today_count;

            int rows = SqlHelper.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(ZGZY.Model.BS_Machine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BS_Machine set ");
            strSql.Append(" type = @type , ");
            strSql.Append(" status = @status , ");
            strSql.Append(" Login_Account = @Login_Account , ");
            strSql.Append(" sum = @sum , ");
            strSql.Append(" OtherOREBonus = @OtherOREBonus , ");
            strSql.Append(" createrdate = @createrdate , ");
            strSql.Append(" start_run_time = @start_run_time , ");
            strSql.Append(" end_run_time = @end_run_time , ");
            strSql.Append(" count_time = @count_time , ");
            strSql.Append(" today_count = @today_count  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@type", SqlDbType.Int,4) ,            
                        new SqlParameter("@status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Login_Account", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@sum", SqlDbType.Decimal) ,            
                        new SqlParameter("@OtherOREBonus", SqlDbType.Int,4) ,            
                        new SqlParameter("@createrdate", SqlDbType.DateTime) ,            
                        new SqlParameter("@start_run_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@end_run_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@count_time", SqlDbType.DateTime) ,            
                        new SqlParameter("@today_count", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.type;
            parameters[2].Value = model.status;
            parameters[3].Value = model.Login_Account;
            parameters[4].Value = model.sum;
            parameters[5].Value = model.OtherOREBonus;
            parameters[6].Value = model.createrdate;
            parameters[7].Value = model.start_run_time;
            parameters[8].Value = model.end_run_time;
            parameters[9].Value = model.count_time;
            parameters[10].Value = model.today_count;

            int rows = SqlHelper.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BS_Machine ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;

            int rows = SqlHelper.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BS_Machine ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = SqlHelper.ExecuteSql(strSql.ToString());
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
        public ZGZY.Model.BS_Machine GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, type, status, Login_Account, sum, OtherOREBonus, createrdate, start_run_time, end_run_time, count_time, today_count  ");
            strSql.Append("  from BS_Machine ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};

            parameters[0].Value = id;

            ZGZY.Model.BS_Machine model = new ZGZY.Model.BS_Machine();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);
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
        public ZGZY.Model.BS_Machine DataRowToModel(DataRow row)
        {
            ZGZY.Model.BS_Machine model = new ZGZY.Model.BS_Machine();
            if (row != null)
            {

                if (row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["type"].ToString() != "")
                {
                    model.type = int.Parse(row["type"].ToString());
                }
                if (row["status"].ToString() != "")
                {
                    model.status = int.Parse(row["status"].ToString());
                }
                model.Login_Account = row["Login_Account"].ToString();
                if (row["sum"].ToString() != "")
                {
                    model.sum = decimal.Parse(row["sum"].ToString());

                }
                if (row["OtherOREBonus"].ToString() != "")
                {
                    model.OtherOREBonus = int.Parse(row["OtherOREBonus"].ToString());
                }
                if (row["createrdate"].ToString() != "")
                {
                    model.createrdate = DateTime.Parse(row["createrdate"].ToString());
                }
                if (row["start_run_time"].ToString() != "")
                {
                    model.start_run_time = DateTime.Parse(row["start_run_time"].ToString());
                }
                if (row["end_run_time"].ToString() != "")
                {
                    model.end_run_time = DateTime.Parse(row["end_run_time"].ToString());
                }
                if (row["count_time"].ToString() != "")
                {
                    model.count_time = DateTime.Parse(row["count_time"].ToString());
                }
                if (row["today_count"].ToString() != "")
                {
                    model.today_count = int.Parse(row["today_count"].ToString());
                }

            }
            return model;
        }


        /// <summary>
        /// 得到对象实体泛型
        /// </summary>
        public List<ZGZY.Model.BS_Machine> DataTableToList(DataTable table)
        {
            List<ZGZY.Model.BS_Machine> rr = new List<Model.BS_Machine>();
            if (table != null && table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    ZGZY.Model.BS_Machine model = new ZGZY.Model.BS_Machine();
                    if (row["id"].ToString() != "")
                    {
                        model.id = int.Parse(row["id"].ToString());
                    }
                    if (row["type"].ToString() != "")
                    {
                        model.type = int.Parse(row["type"].ToString());
                    }
                    if (row["status"].ToString() != "")
                    {
                        model.status = int.Parse(row["status"].ToString());
                    }
                    model.Login_Account = row["Login_Account"].ToString();
                    if (row["sum"].ToString() != "")
                    {
                        model.sum = decimal.Parse(row["sum"].ToString());

                    }
                    if (row["OtherOREBonus"].ToString() != "")
                    {
                        model.OtherOREBonus = int.Parse(row["OtherOREBonus"].ToString());
                    }
                    if (row["createrdate"].ToString() != "")
                    {
                        model.createrdate = DateTime.Parse(row["createrdate"].ToString());
                    }
                    if (row["start_run_time"].ToString() != "")
                    {
                        model.start_run_time = DateTime.Parse(row["start_run_time"].ToString());
                    }
                    if (row["end_run_time"].ToString() != "")
                    {
                        model.end_run_time = DateTime.Parse(row["end_run_time"].ToString());
                    }
                    if (row["count_time"].ToString() != "")
                    {
                        model.count_time = DateTime.Parse(row["count_time"].ToString());
                    }
                    if (row["today_count"].ToString() != "")
                    {
                        model.today_count = int.Parse(row["today_count"].ToString());
                    }
                    rr.Add(model);
                }
            }

            return rr;
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM BS_Machine ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.Query(strSql.ToString());
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
            strSql.Append(" FROM BS_Machine ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM BS_Machine ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = SqlHelper.GetSingle(strSql.ToString());
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from BS_Machine T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return SqlHelper.Query(strSql.ToString());
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
            parameters[0].Value = "BS_Machine";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return SqlHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 每小时发放矿机币 return -1表示失败 0表示执行成功 >0表示执行失败
        /// </summary>
        /// <returns></returns>
        public int AccountOREByDays(string Login_Account, decimal MachineCount, int MachineId, string ID, decimal Income, decimal Pay, decimal Remain, string Kind, string Remark, decimal TomoroCount)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@Login_Account", SqlDbType.VarChar, 20),
                    new SqlParameter("@MachineCount", SqlDbType.Decimal),
                    new SqlParameter("@MachineId", SqlDbType.Int),
                    new SqlParameter("@ID", SqlDbType.VarChar,20),
                    new SqlParameter("@Income", SqlDbType.Decimal),
                    new SqlParameter("@Remain", SqlDbType.Decimal),
                    new SqlParameter("@Kind", SqlDbType.VarChar,20),
                    new SqlParameter("@Remark", SqlDbType.VarChar,20),
                    new SqlParameter("@TomoroCount", SqlDbType.Decimal),
                    };
            parameters[0].Value = Login_Account;
            parameters[1].Value = MachineCount;
            parameters[2].Value = MachineId;
            parameters[3].Value = ID;
            parameters[4].Value = Income;
            parameters[5].Value = Remain;
            parameters[6].Value = Kind;
            parameters[7].Value = Remark;
            parameters[8].Value = TomoroCount;
            var tmp = SqlHelper.RunProcedure("AccountOREByDays", parameters, "AccountOREByDays").Tables[0];
            int result = -1;
            if (tmp != null && tmp.Rows.Count > 0)
            {
                int.TryParse(tmp.Rows[0][0].ToString(), out result);
            }
            return result;
        }

        /// <summary>
        /// 购买矿机
        /// </summary>
        /// <returns></returns>
        public int BuyMachine(int type, string Login_Account, DateTime start_run_time, DateTime end_run_time, int MachinePrice, string Remark, int TodayCount)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@type", SqlDbType.Int, 4),
                    new SqlParameter("@Login_Account", SqlDbType.VarChar,20),
                    new SqlParameter("@start_run_time", SqlDbType.DateTime),
                    new SqlParameter("@end_run_time", SqlDbType.DateTime),
                    new SqlParameter("@MachinePrice", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,100),
                    new SqlParameter("@TodayCount", SqlDbType.Int,4),
                    };
            parameters[0].Value = type;
            parameters[1].Value = Login_Account;
            parameters[2].Value = start_run_time;
            parameters[3].Value = end_run_time;
            parameters[4].Value = MachinePrice;
            parameters[5].Value = Remark;
            parameters[6].Value = TodayCount;
            var tmp = SqlHelper.RunProcedure("BuyMachine", parameters, "BuyMachine").Tables[0];
            int result = -1;
            if (tmp != null && tmp.Rows.Count > 0)
            {
                int.TryParse(tmp.Rows[0][0].ToString(), out result);
            }
            return result;

        }


        /// <summary>
        /// 续租矿机
        /// </summary>
        /// <returns></returns>
        public int ReletMachine(DateTime start_run_time, DateTime end_run_time, DateTime count_time, int status, int id, int MachinePrice, string Login_Account, string Remark)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@start_run_time", SqlDbType.DateTime),
                    new SqlParameter("@end_run_time", SqlDbType.DateTime),
                    new SqlParameter("@count_time", SqlDbType.DateTime),
                    new SqlParameter("@status", SqlDbType.Int,4),
                    new SqlParameter("@id", SqlDbType.Int),
                    new SqlParameter("@MachinePrice", SqlDbType.Int),
                    new SqlParameter("@Login_Account", SqlDbType.VarChar,20),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,100),
                    };
            parameters[0].Value = start_run_time;
            parameters[1].Value = end_run_time;
            parameters[2].Value = count_time;
            parameters[3].Value = status;
            parameters[4].Value = id;
            parameters[5].Value = MachinePrice;
            parameters[6].Value = Login_Account;
            parameters[7].Value = Remark;

            var tmp = SqlHelper.RunProcedure("ReletMachine", parameters, "BuyMachine").Tables[0];
            int result = -1;
            if (tmp != null && tmp.Rows.Count > 0)
            {
                int.TryParse(tmp.Rows[0][0].ToString(), out result);
            }
            return result;

        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZGZY.Model.BS_Machine GetModelByAccount(string Login_Account)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from BS_Machine ");
            strSql.Append(" where Login_Account=@Login_Account and status=2 ");
            SqlParameter[] parameters = {
					new SqlParameter("@Login_Account", SqlDbType.VarChar,20)		
                                        };
            parameters[0].Value = Login_Account;

            ZGZY.Model.BS_Machine model = new ZGZY.Model.BS_Machine();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);
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
        /// GetModelList
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<ZGZY.Model.BS_Machine> GetModelList(string where)
        {
            var Tables = GetList(where).Tables[0];
            if (Tables != null && Tables.Rows.Count > 0)
            {
                return DataTableToList(Tables);
            }
            return null;
        }

        #endregion  ExtensionMethod



        /// <summary>
        /// 根据用户账号查询是否有矿机
        /// </summary>
        /// <param name="Login_Account"></param>
        /// <returns></returns>
        public ZGZY.Model.BS_Machine GetMachineByAccount(string Login_Account)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from BS_Machine ");
            strSql.Append(" where Login_Account=@Login_Account  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Login_Account", SqlDbType.VarChar,20)		
                                        };
            parameters[0].Value = Login_Account;

            ZGZY.Model.BS_Machine model = new ZGZY.Model.BS_Machine();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);
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
        /// 过期矿机
        /// </summary>
        /// <returns></returns>
        public int MachinePass()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BS_Machine set status=3 where end_run_time<=getdate() and status=2");
            int result = SqlHelper.ExecuteSql(strSql.ToString());
            return result;
        }

    }
}

