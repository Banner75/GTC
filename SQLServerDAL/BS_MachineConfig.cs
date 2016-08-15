using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using ZGZY.IDAL;
using ZGZY.Common;
namespace ZGZY.SQLServerDAL  
{
	 	//BS_MachineConfig
		public partial class BS_MachineConfig: IBS_MachineConfig
	{
   		     
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BS_MachineConfig");
			strSql.Append(" where ");
			                                       strSql.Append(" id = @id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;
            var result= SqlHelper.GetSingle(strSql.ToString(), parameters);
            if (Common.TypeConverter.ObjectToInt(result) > 0)
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
		public int Add(ZGZY.Model.BS_MachineConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BS_MachineConfig(");
            strSql.Append("MachineName,MachinePrice,MinProfit,MaxProfit,Tenancy,Maximum，JianDLayers");
			strSql.Append(") values (");
            strSql.Append("@MachineName,@MachinePrice,@MinProfit,@MaxProfit,@Tenancy,@Maximu,@JianDLayers");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@MachineName", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@MachinePrice", SqlDbType.Int,4) ,            
                        new SqlParameter("@MinProfit", SqlDbType.Int,4) ,            
                        new SqlParameter("@MaxProfit", SqlDbType.Int,4) ,            
                        new SqlParameter("@Tenancy", SqlDbType.Int,4) ,            
                        new SqlParameter("@Maximum", SqlDbType.Int,4),            
                        new SqlParameter("@JianDLayers", SqlDbType.Int,4)                       
            };
			            
            parameters[0].Value = model.MachineName;                        
            parameters[1].Value = model.MachinePrice;                        
            parameters[2].Value = model.MinProfit;                        
            parameters[3].Value = model.MaxProfit;                        
            parameters[4].Value = model.Tenancy;                        
            parameters[5].Value = model.Maximum;                        
            parameters[6].Value = model.JianDLayers;

			   
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
		public bool Update(ZGZY.Model.BS_MachineConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BS_MachineConfig set ");
			                                                
            strSql.Append(" MachineName = @MachineName , ");                                    
            strSql.Append(" MachinePrice = @MachinePrice , ");                                    
            strSql.Append(" MinProfit = @MinProfit , ");                                    
            strSql.Append(" MaxProfit = @MaxProfit , ");                                    
            strSql.Append(" Tenancy = @Tenancy , ");                                    
            strSql.Append(" Maximum = @Maximum ,  ");
            strSql.Append(" JianDLayers = @JianDLayers  ");
            strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@MachineName", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@MachinePrice", SqlDbType.Int,4) ,            
                        new SqlParameter("@MinProfit", SqlDbType.Int,4) ,            
                        new SqlParameter("@MaxProfit", SqlDbType.Int,4) ,            
                        new SqlParameter("@Tenancy", SqlDbType.Int,4) ,            
                        new SqlParameter("@Maximum", SqlDbType.Int,4),             
                        new SqlParameter("@JianDLayers", SqlDbType.Int,4)                           
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.MachineName;                        
            parameters[2].Value = model.MachinePrice;                        
            parameters[3].Value = model.MinProfit;                        
            parameters[4].Value = model.MaxProfit;                        
            parameters[5].Value = model.Tenancy;                        
            parameters[6].Value = model.Maximum;
            parameters[7].Value = model.JianDLayers; 
                      
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
			strSql.Append("delete from BS_MachineConfig ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
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
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BS_MachineConfig ");
			strSql.Append(" where ID in ("+idlist + ")  ");
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
		public ZGZY.Model.BS_MachineConfig GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, MachineName, MachinePrice, MinProfit, MaxProfit, Tenancy, Maximum  ");			
			strSql.Append("  from BS_MachineConfig ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			
			ZGZY.Model.BS_MachineConfig model=new ZGZY.Model.BS_MachineConfig();
			DataSet ds=SqlHelper.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
																																				model.MachineName= ds.Tables[0].Rows[0]["MachineName"].ToString();
																												if(ds.Tables[0].Rows[0]["MachinePrice"].ToString()!="")
				{
					model.MachinePrice=int.Parse(ds.Tables[0].Rows[0]["MachinePrice"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["MinProfit"].ToString()!="")
				{
					model.MinProfit=int.Parse(ds.Tables[0].Rows[0]["MinProfit"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["MaxProfit"].ToString()!="")
				{
					model.MaxProfit=int.Parse(ds.Tables[0].Rows[0]["MaxProfit"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Tenancy"].ToString()!="")
				{
					model.Tenancy=int.Parse(ds.Tables[0].Rows[0]["Tenancy"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Maximum"].ToString()!="")
				{
					model.Maximum=int.Parse(ds.Tables[0].Rows[0]["Maximum"].ToString());
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
			strSql.Append(" FROM BS_MachineConfig ");
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
			strSql.Append(" FROM BS_MachineConfig ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return SqlHelper.Query(strSql.ToString());
		}
            /// <summary>
            /// GetModelList
            /// </summary>
            /// <param name="where"></param>
            /// <returns></returns>
        public List<ZGZY.Model.BS_MachineConfig> GetModelList(string where) 
        {
            var Tables = GetList(where).Tables[0];
            if (Tables != null && Tables.Rows.Count > 0) 
            {
                return DataTableToList(Tables);
            }
            return null;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZGZY.Model.BS_MachineConfig> DataTableToList(DataTable dt)
        {
            List<ZGZY.Model.BS_MachineConfig> modelList = new List<ZGZY.Model.BS_MachineConfig>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZGZY.Model.BS_MachineConfig model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ZGZY.Model.BS_MachineConfig();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.MachineName = dt.Rows[n]["MachineName"].ToString();
                    if (dt.Rows[n]["MachinePrice"].ToString() != "")
                    {
                        model.MachinePrice = int.Parse(dt.Rows[n]["MachinePrice"].ToString());
                    }
                    if (dt.Rows[n]["MinProfit"].ToString() != "")
                    {
                        model.MinProfit = int.Parse(dt.Rows[n]["MinProfit"].ToString());
                    }
                    if (dt.Rows[n]["MaxProfit"].ToString() != "")
                    {
                        model.MaxProfit = int.Parse(dt.Rows[n]["MaxProfit"].ToString());
                    }
                    if (dt.Rows[n]["Tenancy"].ToString() != "")
                    {
                        model.Tenancy = int.Parse(dt.Rows[n]["Tenancy"].ToString());
                    }
                    if (dt.Rows[n]["Maximum"].ToString() != "")
                    {
                        model.Maximum = int.Parse(dt.Rows[n]["Maximum"].ToString());
                    }
                    if (dt.Rows[n]["JianDLayers"].ToString() != "")
                    {
                        model.JianDLayers = int.Parse(dt.Rows[n]["JianDLayers"].ToString());
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }

   
	}
}

