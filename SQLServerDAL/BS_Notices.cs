using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using ZGZY.IDAL;
using ZGZY.Common;
namespace ZGZY.SQLServerDAL  
{
	 	//BS_Notices
		public partial class BS_Notices: IBS_Notices
	{
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZGZY.Model.BS_Notices model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BS_Notices(");			
            strSql.Append("Title,Contents,State,Kind,Author,Created_Date,Last_Updated_By,Last_Updated_Date");
			strSql.Append(") values (");
            strSql.Append("@Title,@Contents,@State,@Kind,@Author,@Created_Date,@Last_Updated_By,@Last_Updated_Date");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Title", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@Contents", SqlDbType.Text) ,            
                        new SqlParameter("@State", SqlDbType.Int,4) ,            
                        new SqlParameter("@Kind", SqlDbType.Int,4) ,            
                        new SqlParameter("@Author", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@Created_Date", SqlDbType.DateTime) ,            
                        new SqlParameter("@Last_Updated_By", SqlDbType.Int,4) ,            
                        new SqlParameter("@Last_Updated_Date", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = model.Title;                        
            parameters[1].Value = model.Contents;                        
            parameters[2].Value = model.State;                        
            parameters[3].Value = model.Kind;                        
            parameters[4].Value = model.Author;                        
            parameters[5].Value = model.CreatedDate;                        
            parameters[6].Value = model.LastUpdatedBy;
            parameters[7].Value = model.LastUpdatedDate;

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
		public bool Update(ZGZY.Model.BS_Notices model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BS_Notices set ");
			                                                
            strSql.Append(" Title = @Title , ");                                    
            strSql.Append(" Contents = @Contents , ");                                    
            strSql.Append(" State = @State , ");                                    
            strSql.Append(" Kind = @Kind , ");                                    
            strSql.Append(" Author = @Author , ");                                    
            strSql.Append(" Created_Date = @Created_Date , ");                                    
            strSql.Append(" Last_Updated_By = @Last_Updated_By , ");                                    
            strSql.Append(" Last_Updated_Date = @Last_Updated_Date  ");            			
			strSql.Append(" where ID=@ID ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Title", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@Contents", SqlDbType.Text) ,            
                        new SqlParameter("@State", SqlDbType.Int,4) ,            
                        new SqlParameter("@Kind", SqlDbType.Int,4) ,            
                        new SqlParameter("@Author", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@Created_Date", SqlDbType.DateTime) ,            
                        new SqlParameter("@Last_Updated_By", SqlDbType.Int,4) ,            
                        new SqlParameter("@Last_Updated_Date", SqlDbType.DateTime)             
              
            };
						            
            parameters[0].Value = model.ID;                        
            parameters[1].Value = model.Title;                        
            parameters[2].Value = model.Contents;                        
            parameters[3].Value = model.State;                        
            parameters[4].Value = model.Kind;                        
            parameters[5].Value = model.Author;
            parameters[6].Value = model.CreatedDate;
            parameters[7].Value = model.LastUpdatedBy;
            parameters[8].Value = model.LastUpdatedDate;
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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BS_Notices ");
			strSql.Append(" where ID=@ID");
						SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;


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
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BS_Notices ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public ZGZY.Model.BS_Notices GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, Title, Contents, State, Kind, Author, Created_Date, Last_Updated_By, Last_Updated_Date  ");			
			strSql.Append("  from BS_Notices ");
			strSql.Append(" where ID=@ID");
						SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			
			ZGZY.Model.BS_Notices model=new ZGZY.Model.BS_Notices();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
																																				model.Title= ds.Tables[0].Rows[0]["Title"].ToString();
																																model.Contents= ds.Tables[0].Rows[0]["Contents"].ToString();
																												if(ds.Tables[0].Rows[0]["State"].ToString()!="")
				{
					model.State=int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Kind"].ToString()!="")
				{
					model.Kind=int.Parse(ds.Tables[0].Rows[0]["Kind"].ToString());
				}
																																				model.Author= ds.Tables[0].Rows[0]["Author"].ToString();
																												if(ds.Tables[0].Rows[0]["Created_Date"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(ds.Tables[0].Rows[0]["Created_Date"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Last_Updated_By"].ToString()!="")
				{
					model.LastUpdatedBy=int.Parse(ds.Tables[0].Rows[0]["Last_Updated_By"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Last_Updated_Date"].ToString()!="")
				{
					model.LastUpdatedDate=DateTime.Parse(ds.Tables[0].Rows[0]["Last_Updated_Date"].ToString());
				}
																														
				return model;
			}
			else
			{
				return null;
			}
		}
		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM BS_Notices ");
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
			strSql.Append(" * ");
			strSql.Append(" FROM BS_Notices ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return SqlHelper.Query(strSql.ToString());
		}

   
	}
}

