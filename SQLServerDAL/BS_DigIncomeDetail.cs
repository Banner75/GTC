/**  版本信息模板在安装目录下，可自行修改。
* BS_DigIncomeDetail.cs
*
* 功 能： N/A
* 类 名： BS_DigIncomeDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/2 10:45:25   N/A    初版
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
	/// 数据访问类:BS_DigIncomeDetail
	/// </summary>
	public partial class BS_DigIncomeDetail:IBS_DigIncomeDetail
	{
		public BS_DigIncomeDetail()
		{}
		#region  BasicMethod

		


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ZGZY.Model.BS_DigIncomeDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BS_DigIncomeDetail(");
			strSql.Append("ID,Income,Pay,Remain,SubAccount,Machine,Kind,Occur_Date,Remark)");
			strSql.Append(" values (");
			strSql.Append("@ID,@Income,@Pay,@Remain,@SubAccount,@Machine,@Kind,@Occur_Date,@Remark)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,20),
					new SqlParameter("@Income", SqlDbType.Decimal,9),
					new SqlParameter("@Pay", SqlDbType.Decimal,9),
					new SqlParameter("@Remain", SqlDbType.Decimal,9),
					new SqlParameter("@SubAccount", SqlDbType.VarChar,20),
					new SqlParameter("@Machine", SqlDbType.Int,4),
					new SqlParameter("@Kind", SqlDbType.VarChar,20),
					new SqlParameter("@Occur_Date", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar,250)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Income;
			parameters[2].Value = model.Pay;
			parameters[3].Value = model.Remain;
			parameters[4].Value = model.SubAccount;
			parameters[5].Value = model.Machine;
			parameters[6].Value = model.Kind;
			parameters[7].Value = model.Occur_Date;
			parameters[8].Value = model.Remark;

			int rows=SqlHelper.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(ZGZY.Model.BS_DigIncomeDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BS_DigIncomeDetail set ");
			strSql.Append("Income=@Income,");
			strSql.Append("Pay=@Pay,");
			strSql.Append("Remain=@Remain,");
			strSql.Append("SubAccount=@SubAccount,");
			strSql.Append("Machine=@Machine,");
			strSql.Append("Kind=@Kind,");
			strSql.Append("Occur_Date=@Occur_Date,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Income", SqlDbType.Decimal,9),
					new SqlParameter("@Pay", SqlDbType.Decimal,9),
					new SqlParameter("@Remain", SqlDbType.Decimal,9),
					new SqlParameter("@SubAccount", SqlDbType.VarChar,20),
					new SqlParameter("@Machine", SqlDbType.Int,4),
					new SqlParameter("@Kind", SqlDbType.VarChar,20),
					new SqlParameter("@Occur_Date", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar,20),
					new SqlParameter("@ID", SqlDbType.VarChar,20)};
			parameters[0].Value = model.Income;
			parameters[1].Value = model.Pay;
			parameters[2].Value = model.Remain;
			parameters[3].Value = model.SubAccount;
			parameters[4].Value = model.Machine;
			parameters[5].Value = model.Kind;
			parameters[6].Value = model.Occur_Date;
			parameters[7].Value = model.Remark;
			parameters[8].Value = model.ID;

			int rows=SqlHelper.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BS_DigIncomeDetail ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,20)			};
			parameters[0].Value = ID;

			int rows=SqlHelper.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BS_DigIncomeDetail ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=SqlHelper.ExecuteSql(strSql.ToString());
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
		public ZGZY.Model.BS_DigIncomeDetail GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Income,Pay,Remain,SubAccount,Machine,Kind,Occur_Date,Remark from BS_DigIncomeDetail ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,20)			};
			parameters[0].Value = ID;

			ZGZY.Model.BS_DigIncomeDetail model=new ZGZY.Model.BS_DigIncomeDetail();
			DataSet ds=SqlHelper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public ZGZY.Model.BS_DigIncomeDetail DataRowToModel(DataRow row)
		{
			ZGZY.Model.BS_DigIncomeDetail model=new ZGZY.Model.BS_DigIncomeDetail();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["Income"]!=null && row["Income"].ToString()!="")
				{
					model.Income=decimal.Parse(row["Income"].ToString());
				}
				if(row["Pay"]!=null && row["Pay"].ToString()!="")
				{
					model.Pay=decimal.Parse(row["Pay"].ToString());
				}
				if(row["Remain"]!=null && row["Remain"].ToString()!="")
				{
					model.Remain=decimal.Parse(row["Remain"].ToString());
				}
				if(row["SubAccount"]!=null)
				{
					model.SubAccount=row["SubAccount"].ToString();
				}
				if(row["Machine"]!=null && row["Machine"].ToString()!="")
				{
					model.Machine=int.Parse(row["Machine"].ToString());
				}
				if(row["Kind"]!=null)
				{
					model.Kind=row["Kind"].ToString();
				}
				if(row["Occur_Date"]!=null && row["Occur_Date"].ToString()!="")
				{
					model.Occur_Date=DateTime.Parse(row["Occur_Date"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Income,Pay,Remain,SubAccount,Machine,Kind,Occur_Date,Remark ");
			strSql.Append(" FROM BS_DigIncomeDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return SqlHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,Income,Pay,Remain,SubAccount,Machine,Kind,Occur_Date,Remark ");
			strSql.Append(" FROM BS_DigIncomeDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return SqlHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM BS_DigIncomeDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from BS_DigIncomeDetail T ");
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
			parameters[0].Value = "BS_DigIncomeDetail";
			parameters[1].Value = "ID";
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
        /// 获取记录总数
        /// </summary>
        public decimal GetDailyIncome(string Account,int day)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull(sum(isnull(Income,0)),0)  FROM BS_DigIncomeDetail where SubAccount='" + Account + "' and DATEDIFF(DAY,Occur_Date,GETDATE())=" + day + " and Kind=1 ");
            
            object obj = SqlHelper.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }

        /// <summary>
        /// 获取奖金
        /// </summary>
        public decimal GetBonus(string Account,int day)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull(sum(isnull(Income,0)),0)  FROM BS_DigIncomeDetail where SubAccount='" + Account + "' and DATEDIFF(DAY,Occur_Date,GETDATE())=" + day + " and (Kind=2 or Kind=5) ");
            
            object obj = SqlHelper.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public decimal GetDailyIncome(int day)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull(sum(isnull(Income,0)),0)  FROM BS_DigIncomeDetail where  DATEDIFF(DAY,Occur_Date,GETDATE())=" + day + " and Kind=1 ");

            object obj = SqlHelper.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }

        /// <summary>
        /// 判断今日是否发放过奖金
        /// </summary>
        public decimal GetIncomeCount(string Account, DateTime stare, DateTime end, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull(sum(isnull(Income,0)),0)  FROM BS_DigIncomeDetail where SubAccount='" + Account + "' and Occur_Date>'" + stare.ToString("yyyy-hh-dd") + " 00:00:00' and Occur_Date<'" + stare.ToString("yyyy-hh-dd") + " 23:59:59' and Kind=" + type + "  ");

            object obj = SqlHelper.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }
        /// <summary>
        /// 判断今日是否发放过奖金
        /// </summary>
        public decimal GetDailyIncomeFromToDay(string Account, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*)  FROM BS_DigIncomeDetail where SubAccount='" + Account + "' and DATEDIFF(DAY,Occur_Date,GETDATE())=0 and Kind=" + type + "  ");

            object obj = SqlHelper.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }
        
        /// <summary>
        /// 增加奖金 
        /// </summary>
        /// <returns></returns>
        public int AddLssuebonus(string Login_Account, decimal bonus, decimal balance, string ID, string Remark)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@Login_Account", SqlDbType.VarChar,20),
                    new SqlParameter("@bonus", SqlDbType.Decimal,18),
                    new SqlParameter("@balance", SqlDbType.Decimal,18),
                    new SqlParameter("@ID", SqlDbType.VarChar,20),
                    new SqlParameter("@Remark", SqlDbType.VarChar,250)
                                        };
            parameters[0].Value = Login_Account;
            parameters[1].Value = bonus;
            parameters[2].Value = balance;
            parameters[3].Value = ID;
            parameters[4].Value = Remark;
           DataSet ds= SqlHelper.RunProcedure("Lssuebonus", parameters, "tb");
           if (ds != null && ds.Tables[0].Rows.Count > 0)
           {
               return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
           }
           return 0;
        }
		#endregion  ExtensionMethod

        /// <summary>
        /// 获取矿机币流水
        /// </summary>
        /// <param name="strwhere">条件</param>
        /// <returns></returns>
        public DataTable GetDigIncomeDetailList(string strwhere)
        {
            string text = string.Empty;
            text = "select ID,Income,Pay,Remain,SubAccount,Machine,Kind,Occur_Date,Remark from BS_DigIncomeDetail";
            if (!string.IsNullOrWhiteSpace(strwhere))
            {
                text += string.Format(" where {0}", strwhere);
            }
            var datatable = ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, text);
            return datatable;
        }
	}
}

