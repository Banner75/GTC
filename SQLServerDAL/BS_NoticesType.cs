using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using ZGZY.IDAL;
using ZGZY.Common;
namespace ZGZY.SQLServerDAL  
{
	 	//BS_NoticesType
		public partial class BS_NoticesType: IBS_NoticesType
	{
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZGZY.Model.BS_NoticesType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BS_NoticesType(");			
            strSql.Append("TypeName,State,DisplayOrder");
			strSql.Append(") values (");
            strSql.Append("@TypeName,@State,@DisplayOrder");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@TypeName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@State", SqlDbType.Int,4) ,            
                        new SqlParameter("@DisplayOrder", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.TypeName;                        
            parameters[1].Value = model.State;                        
            parameters[2].Value = model.DisplayOrder;

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
		public bool Update(ZGZY.Model.BS_NoticesType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BS_NoticesType set ");
			                                                
            strSql.Append(" TypeName = @TypeName , ");                                    
            strSql.Append(" State = @State , ");                                    
            strSql.Append(" DisplayOrder = @DisplayOrder  ");            			
			strSql.Append(" where ID=@ID ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@TypeName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@State", SqlDbType.Int,4) ,            
                        new SqlParameter("@DisplayOrder", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.ID;                        
            parameters[1].Value = model.TypeName;                        
            parameters[2].Value = model.State;                        
            parameters[3].Value = model.DisplayOrder;
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
			strSql.Append("delete from BS_NoticesType ");
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
		/// 得到一个对象实体
		/// </summary>
		public ZGZY.Model.BS_NoticesType GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, TypeName, State, DisplayOrder  ");			
			strSql.Append("  from BS_NoticesType ");
			strSql.Append(" where ID=@ID");
						SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			
			ZGZY.Model.BS_NoticesType model=new ZGZY.Model.BS_NoticesType();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
																																				model.TypeName= ds.Tables[0].Rows[0]["TypeName"].ToString();
																												if(ds.Tables[0].Rows[0]["State"].ToString()!="")
				{
					model.State=int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["DisplayOrder"].ToString()!="")
				{
					model.DisplayOrder=int.Parse(ds.Tables[0].Rows[0]["DisplayOrder"].ToString());
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
			strSql.Append(" FROM BS_NoticesType ");
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
			strSql.Append(" FROM BS_NoticesType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return SqlHelper.Query(strSql.ToString());
		}

        /// <summary>
        /// 批量删除新闻类型
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int DeleteRange(string ids)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BS_NoticesType ");
            strSql.Append(string.Format(" where ID in({0})", ids));
            int rows = SqlHelper.ExecuteSql(strSql.ToString());
            return rows;
        }
	}
}

