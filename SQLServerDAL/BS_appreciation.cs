﻿/**  版本信息模板在安装目录下，可自行修改。
* BS_appreciation.cs
*
* 功 能： N/A
* 类 名： BS_appreciation
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/11 10:45:53   N/A    初版
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
	/// 数据访问类:BS_appreciation
	/// </summary>
	public partial class BS_appreciation:IBS_appreciation
	{
		public BS_appreciation()
		{}
		#region  BasicMethod


	
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZGZY.Model.BS_appreciation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BS_appreciation(");
			strSql.Append("addtime,TodayPrice,LastPrice)");
			strSql.Append(" values (");
			strSql.Append("@addtime,@TodayPrice,@LastPrice)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@TodayPrice", SqlDbType.Decimal,9),
					new SqlParameter("@LastPrice", SqlDbType.Decimal,9)};
			parameters[0].Value = model.addtime;
			parameters[1].Value = model.TodayPrice;
			parameters[2].Value = model.LastPrice;

            object obj = SqlHelper.ExecuteSql(strSql.ToString(), parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(ZGZY.Model.BS_appreciation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BS_appreciation set ");
			strSql.Append("addtime=@addtime,");
			strSql.Append("TodayPrice=@TodayPrice,");
			strSql.Append("LastPrice=@LastPrice");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@TodayPrice", SqlDbType.Decimal,9),
					new SqlParameter("@LastPrice", SqlDbType.Decimal,9),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.addtime;
			parameters[1].Value = model.TodayPrice;
			parameters[2].Value = model.LastPrice;
			parameters[3].Value = model.id;

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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BS_appreciation ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BS_appreciation ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public ZGZY.Model.BS_appreciation GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,addtime,TodayPrice,LastPrice from BS_appreciation ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			ZGZY.Model.BS_appreciation model=new ZGZY.Model.BS_appreciation();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);
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
		public ZGZY.Model.BS_appreciation DataRowToModel(DataRow row)
		{
			ZGZY.Model.BS_appreciation model=new ZGZY.Model.BS_appreciation();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["addtime"]!=null && row["addtime"].ToString()!="")
				{
					model.addtime=DateTime.Parse(row["addtime"].ToString());
				}
				if(row["TodayPrice"]!=null && row["TodayPrice"].ToString()!="")
				{
					model.TodayPrice=decimal.Parse(row["TodayPrice"].ToString());
				}
				if(row["LastPrice"]!=null && row["LastPrice"].ToString()!="")
				{
					model.LastPrice=decimal.Parse(row["LastPrice"].ToString());
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
			strSql.Append("select id,addtime,TodayPrice,LastPrice ");
			strSql.Append(" FROM BS_appreciation ");
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
			strSql.Append(" id,addtime,TodayPrice,LastPrice ");
			strSql.Append(" FROM BS_appreciation ");
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
			strSql.Append("select count(1) FROM BS_appreciation ");
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
			strSql.Append(")AS Row, T.*  from BS_appreciation T ");
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
			parameters[0].Value = "BS_appreciation";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return SQLServerDAL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

