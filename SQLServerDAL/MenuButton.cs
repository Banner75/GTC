using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ZGZY.Common;

namespace ZGZY.SQLServerDAL
{
    /// <summary>
    /// 菜单按钮（SQL Server数据库实现）
    /// </summary>
    public class MenuButton : ZGZY.IDAL.IMenuButton
    {
       
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddMenuButton(ZGZY.Model.MenuButton model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbMenuButton(");
            strSql.Append("MenuId,ButtonId");
            strSql.Append(") values (");
            strSql.Append("@MenuId,@ButtonId");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@MenuId", SqlDbType.Int,4) ,            
                        new SqlParameter("@ButtonId", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.MenuId;
            parameters[1].Value = model.ButtonId;
          return   SqlHelper.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateMenuButton(ZGZY.Model.MenuButton model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbMenuButton set ");

            strSql.Append(" MenuId = @MenuId , ");
            strSql.Append(" ButtonId = @ButtonId  ");
            strSql.Append(" where MenuId=@MenuId and ButtonId=@ButtonId  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@MenuId", SqlDbType.Int,4) ,            
                        new SqlParameter("@ButtonId", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.MenuId;
            parameters[1].Value = model.ButtonId;
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
        public bool DeleteMenuButton(int MenuId, int ButtonId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbMenuButton ");
            strSql.Append(" where MenuId=@MenuId and ButtonId=@ButtonId ");
            SqlParameter[] parameters = {
					new SqlParameter("@MenuId", SqlDbType.Int,4),
					new SqlParameter("@ButtonId", SqlDbType.Int,4)			};
            parameters[0].Value = MenuId;
            parameters[1].Value = ButtonId;


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
        public ZGZY.Model.MenuButton GetMenuButtonModel(int MenuId, int ButtonId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MenuId, ButtonId  ");
            strSql.Append("  from tbMenuButton ");
            strSql.Append(" where MenuId=@MenuId and ButtonId=@ButtonId ");
            SqlParameter[] parameters = {
					new SqlParameter("@MenuId", SqlDbType.Int,4),
					new SqlParameter("@ButtonId", SqlDbType.Int,4)			};
            parameters[0].Value = MenuId;
            parameters[1].Value = ButtonId;


            ZGZY.Model.MenuButton model = new ZGZY.Model.MenuButton();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MenuId"].ToString() != "")
                {
                    model.MenuId = int.Parse(ds.Tables[0].Rows[0]["MenuId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ButtonId"].ToString() != "")
                {
                    model.ButtonId = int.Parse(ds.Tables[0].Rows[0]["ButtonId"].ToString());
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
        public DataSet GetMenuButtonList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM tbMenuButton ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.Query(strSql.ToString());
        }

    }
}
