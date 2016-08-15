/**  版本信息模板在安装目录下，可自行修改。
* BS_MachineLog.cs
*
* 功 能： N/A
* 类 名： BS_MachineLog
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
namespace ZGZY.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BS_MachineLog
	/// </summary>
	public partial class BS_MachineLog:IBS_MachineLog
	{
		public BS_MachineLog()
		{}
		#region  BasicMethod

		


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ZGZY.Model.BS_MachineLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BS_MachineLog(");
			strSql.Append("id,give_account,receive_account,machine_id,createdate)");
			strSql.Append(" values (");
			strSql.Append("@id,@give_account,@receive_account,@machine_id,@createdate)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@give_account", SqlDbType.VarChar,20),
					new SqlParameter("@receive_account", SqlDbType.VarChar,20),
					new SqlParameter("@machine_id", SqlDbType.Int,4),
					new SqlParameter("@createdate", SqlDbType.DateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.give_account;
			parameters[2].Value = model.receive_account;
			parameters[3].Value = model.machine_id;
			parameters[4].Value = model.createdate;

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
		public bool Update(ZGZY.Model.BS_MachineLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BS_MachineLog set ");
			strSql.Append("give_account=@give_account,");
			strSql.Append("receive_account=@receive_account,");
			strSql.Append("machine_id=@machine_id,");
			strSql.Append("createdate=@createdate");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@give_account", SqlDbType.VarChar,20),
					new SqlParameter("@receive_account", SqlDbType.VarChar,20),
					new SqlParameter("@machine_id", SqlDbType.Int,4),
					new SqlParameter("@createdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.give_account;
			parameters[1].Value = model.receive_account;
			parameters[2].Value = model.machine_id;
			parameters[3].Value = model.createdate;
			parameters[4].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BS_MachineLog ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BS_MachineLog ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public ZGZY.Model.BS_MachineLog GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,give_account,receive_account,machine_id,createdate from BS_MachineLog ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			ZGZY.Model.BS_MachineLog model=new ZGZY.Model.BS_MachineLog();
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
		public ZGZY.Model.BS_MachineLog DataRowToModel(DataRow row)
		{
			ZGZY.Model.BS_MachineLog model=new ZGZY.Model.BS_MachineLog();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["give_account"]!=null)
				{
					model.give_account=row["give_account"].ToString();
				}
				if(row["receive_account"]!=null)
				{
					model.receive_account=row["receive_account"].ToString();
				}
				if(row["machine_id"]!=null && row["machine_id"].ToString()!="")
				{
					model.machine_id=int.Parse(row["machine_id"].ToString());
				}
				if(row["createdate"]!=null && row["createdate"].ToString()!="")
				{
					model.createdate=DateTime.Parse(row["createdate"].ToString());
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
			strSql.Append("select id,give_account,receive_account,machine_id,createdate ");
			strSql.Append(" FROM BS_MachineLog ");
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
			strSql.Append(" id,give_account,receive_account,machine_id,createdate ");
			strSql.Append(" FROM BS_MachineLog ");
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
			strSql.Append("select count(1) FROM BS_MachineLog ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from BS_MachineLog T ");
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
			parameters[0].Value = "BS_MachineLog";
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

		#endregion  ExtensionMethod
	}
}

