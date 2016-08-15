using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ZGZY.Common;

namespace ZGZY.SQLServerDAL
{
    /// <summary>
    /// 按钮（SQL Server数据库实现）
    /// </summary>
    public class Button : ZGZY.IDAL.IButton
    {
        /// <summary>
        /// 根据菜单标识码和用户id获取此用户拥有该菜单下的哪些按钮权限
        /// </summary>
        public DataTable GetButtonByMenuCodeAndUserId(string menuCode, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct(b.Id) id,b.Code code,b.Name name,b.Icon icon,b.Sort sort from tbUser u");
            strSql.Append(" join tbUserRole ur on u.Id=ur.UserId");
            strSql.Append(" join tbRoleMenuButton rmb on ur.RoleId=rmb.RoleId");
            strSql.Append(" join tbMenu m on rmb.MenuId=m.Id");
            strSql.Append(" join tbButton b on rmb.ButtonId=b.Id");
            strSql.Append(" where u.Id=@Id and m.Code=@MenuCode order by b.Sort");
            SqlParameter[] paras = { 
                                   new SqlParameter("@Id",userId),
                                   new SqlParameter("@MenuCode",menuCode)
                                   };

            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), paras);
        }
        /// <summary>
        /// 判断按钮名称是否存在
        /// </summary>
        /// <param name="name">按钮名称</param>
        /// <returns></returns>
        public bool checkButtonName(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Name from tbButton");
            strSql.Append(" where Name=@Name ");
            SqlParameter[] paras = { 
                                   new SqlParameter("@Name",name)
                                 
                                   };

            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), paras).Rows.Count>0;
        }
        /// <summary>
        /// 判断按钮标识码 是否存在
        /// </summary>
        /// <param name="name">标识码</param>
        /// <returns></returns>
        public bool checkButtonCode(string Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Code from tbButton");
            strSql.Append(" where Code=@Code ");
            SqlParameter[] paras = { 
                                   new SqlParameter("@Code",Code)
                                   };
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), paras).Rows.Count > 0;
        }



        /// <summary>
        /// 新增按钮
        /// </summary>
      public  int  addButton(ZGZY.Model.Button model)
        {
            StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbButton(");			
            strSql.Append("Name,Code,Icon,Sort,AddDate,Description");
			strSql.Append(") values (");
            strSql.Append("@Name,@Code,@Icon,@Sort,@AddDate,@Description");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Name", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Icon", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Sort", SqlDbType.Int,4) ,            
                        new SqlParameter("@AddDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@Description", SqlDbType.VarChar,100)             
              
            };
			            
            parameters[0].Value = model.Name;                        
            parameters[1].Value = model.Code;                        
            parameters[2].Value = model.Icon;                        
            parameters[3].Value = model.Sort;                        
            parameters[4].Value = model.AddDate;                        
            parameters[5].Value = model.Description;                        
			   
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
      /// 编辑按钮
      /// </summary>
      public bool editButton(ZGZY.Model.Button model)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("update tbButton set ");

          strSql.Append(" Name = @Name , ");
          strSql.Append(" Code = @Code , ");
          strSql.Append(" Icon = @Icon , ");
          strSql.Append(" Sort = @Sort , ");
          strSql.Append(" AddDate = @AddDate , ");
          strSql.Append(" Description = @Description  ");
          strSql.Append(" where Id=@Id ");

          SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Name", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Icon", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Sort", SqlDbType.Int,4) ,            
                        new SqlParameter("@AddDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@Description", SqlDbType.VarChar,100)             
              
            };

          parameters[0].Value = model.Id;
          parameters[1].Value = model.Name;
          parameters[2].Value = model.Code;
          parameters[3].Value = model.Icon;
          parameters[4].Value = model.Sort;
          parameters[5].Value = model.AddDate;
          parameters[6].Value = model.Description;
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
      /// 删除按钮
      /// </summary>
     public bool delButton(string Buttonid)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("delete from tbButton ");
          strSql.Append(" where Id=@Id");
          SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
          parameters[0].Value = Buttonid;


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
        /// 获得按钮实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
     public ZGZY.Model.Button getButtonModel(string Id)
     {
         StringBuilder strSql = new StringBuilder();
         strSql.Append("select Id, Name, Code, Icon, Sort, AddDate, Description  ");
         strSql.Append("  from tbButton ");
         strSql.Append(" where Id=@Id");
         SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
         parameters[0].Value = Id;


         ZGZY.Model.Button model = new ZGZY.Model.Button();
         DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);

         if (ds.Tables[0].Rows.Count > 0)
         {
             if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
             {
                 model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
             }
             model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
             model.Code = ds.Tables[0].Rows[0]["Code"].ToString();
             model.Icon = ds.Tables[0].Rows[0]["Icon"].ToString();
             if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
             {
                 model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
             }
             if (ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
             {
                 model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
             }
             model.Description = ds.Tables[0].Rows[0]["Description"].ToString();

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
     public DataSet GetButtonList(string strWhere)
     {
         StringBuilder strSql = new StringBuilder();
         strSql.Append("select * ");
         strSql.Append(" FROM tbButton ");
         if (strWhere.Trim() != "")
         {
             strSql.Append(" where " + strWhere);
         }
         return SqlHelper.Query(strSql.ToString());
     }
    }
}
