using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using ZGZY.IDAL;
using ZGZY.Common;
namespace ZGZY.SQLServerDAL  
{
	 	//BS_MRC_Wallet
		public partial class BS_MRC_Wallet: IBS_MRC_Wallet
	{
   		     
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BS_MRC_Wallet");
			strSql.Append(" where ");
			                                       strSql.Append(" ID = @ID  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;
            var result=Convert.ToInt32(SqlHelper.GetSingle(strSql.ToString(), parameters));
            if (result > 0)
            {
                return true;
            }
            else 
            {
                return false;
            }

            
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZGZY.Model.BS_MRC_Wallet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BS_MRC_Wallet(");			
            strSql.Append("Sum,Type,Status,Remark,CreateDate,Login_Account");
			strSql.Append(") values (");
            strSql.Append("@Sum,@Type,@Status,@Remark,@CreateDate,@Login_Account");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Sum", SqlDbType.Int,4) ,            
                        new SqlParameter("@Type", SqlDbType.Int,4) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@Login_Account", SqlDbType.VarChar,20)             
              
            };
			            
            parameters[0].Value = model.Sum;                        
            parameters[1].Value = model.Type;                        
            parameters[2].Value = model.Status;                        
            parameters[3].Value = model.Remark;                        
            parameters[4].Value = model.CreateDate;                        
            parameters[5].Value = model.Login_Account;                        
			   
			object obj = SqlHelper.GetSingle(strSql.ToString(),parameters);			
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
		public bool Update(ZGZY.Model.BS_MRC_Wallet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BS_MRC_Wallet set ");
			                                                
            strSql.Append(" Sum = @Sum , ");                                    
            strSql.Append(" Type = @Type , ");                                    
            strSql.Append(" Status = @Status , ");                                    
            strSql.Append(" Remark = @Remark , ");                                    
            strSql.Append(" CreateDate = @CreateDate , ");                                    
            strSql.Append(" Login_Account = @Login_Account  ");            			
			strSql.Append(" where ID=@ID ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Sum", SqlDbType.Int,4) ,            
                        new SqlParameter("@Type", SqlDbType.Int,4) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@Login_Account", SqlDbType.VarChar,20)             
              
            };
						            
            parameters[0].Value = model.ID;                        
            parameters[1].Value = model.Sum;                        
            parameters[2].Value = model.Type;                        
            parameters[3].Value = model.Status;                        
            parameters[4].Value = model.Remark;                        
            parameters[5].Value = model.CreateDate;                        
            parameters[6].Value = model.Login_Account;                        
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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BS_MRC_Wallet ");
			strSql.Append(" where ID=@ID");
						SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
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
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BS_MRC_Wallet ");
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
		public ZGZY.Model.BS_MRC_Wallet GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, Sum, Type, Status, Remark, CreateDate, Login_Account  ");			
			strSql.Append("  from BS_MRC_Wallet ");
			strSql.Append(" where ID=@ID");
						SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			
			ZGZY.Model.BS_MRC_Wallet model=new ZGZY.Model.BS_MRC_Wallet();
			DataSet ds=SqlHelper.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Sum"].ToString()!="")
				{
					model.Sum=int.Parse(ds.Tables[0].Rows[0]["Sum"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Type"].ToString()!="")
				{
					model.Type=int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
																																				model.Remark= ds.Tables[0].Rows[0]["Remark"].ToString();
																												if(ds.Tables[0].Rows[0]["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
				}
																																				model.Login_Account= ds.Tables[0].Rows[0]["Login_Account"].ToString();
																										
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
			strSql.Append(" FROM BS_MRC_Wallet ");
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
			strSql.Append(" FROM BS_MRC_Wallet ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return SqlHelper.Query(strSql.ToString());
		}


        /// <summary>
        /// 获取美瑞币流水
        /// </summary>
        /// <param name="strwhere">条件</param>
        /// <returns></returns>
        public DataTable GetMRCWalletLogList(string strwhere)
        {
            string text = string.Empty;
            text = "select ID,Sum,Type,Status,Remark,CreateDate,Login_Account from BS_MRC_Wallet";
            if (!string.IsNullOrWhiteSpace(strwhere))
            {
                text += string.Format(" where {0}", strwhere);
            }
            var datatable = ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, text);
            return datatable;
        }

        /// <summary>
        /// 获取美瑞币消费总额
        /// </summary>
        /// <param name="loginAccount">登录帐号</param>
        /// <returns></returns>
        public int GetMRCPaySum(string loginAccount)
        {
            int paySum = 0;
            string sSql= "select isnull(sum(isnull(sum,0)),0) as paySum from BS_MRC_Wallet where Type=1 and Login_Account='" +loginAccount +"' " ;

            System.Data.SqlClient.SqlDataReader dr = ZGZY.Common.SqlHelper.ExecuteReader(ZGZY.Common.SqlHelper.connStr, CommandType.Text, sSql);
            if (dr.Read())
            {
                paySum =(int)dr["paySum"];
            }

            return paySum;


        }

	}
}

