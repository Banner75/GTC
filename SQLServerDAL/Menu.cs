using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ZGZY.Common;

namespace ZGZY.SQLServerDAL
{
    /// <summary>
    /// 菜单（SQL Server数据库实现）
    /// </summary>
    public class Menu : ZGZY.IDAL.IMenu
    {
        /// <summary>
        /// 根据用户主键id查询用户可以访问的菜单
        /// </summary>
        public DataTable GetUserMenu(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct(m.Name) menuname,m.Id menuid,m.Icon icon,u.Id userid,u.UserId username,m.ParentId menuparentid,m.Sort menusort,m.LinkAddress linkaddress from tbUser u");
            strSql.Append(" join tbUserRole ur on u.Id=ur.UserId");
            strSql.Append(" join tbRoleMenuButton rmb on ur.RoleId=rmb.RoleId");
            strSql.Append(" join tbMenu m on rmb.MenuId=m.Id");
            strSql.Append(" where u.Id=@Id order by m.ParentId,m.Sort");

            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), new SqlParameter("@Id", id));
        }

        /// <summary>
        /// 根据角色id获取此角色可以访问的菜单和菜单下的按钮（编辑角色-菜单使用）
        /// </summary>
        public DataTable GetAllMenu(int roleId)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("select m.Id menuid,m.Name menuname,m.ParentId parentid,m.Icon menuicon,mb.ButtonId buttonid,b.Name buttonname,b.Icon buttonicon,rmb.RoleId roleid,case when isnull(rmb.ButtonId , 0) = 0 then 'false' else 'true' end checked");
            sqlStr.Append(" from tbMenu m");
            sqlStr.Append(" left join tbMenuButton mb on m.Id=mb.MenuId");
            sqlStr.Append(" left join tbButton b on mb.ButtonId=b.Id");
            sqlStr.Append(" left join tbRoleMenuButton rmb on(mb.MenuId=rmb.MenuId and mb.ButtonId=rmb.ButtonId and rmb.RoleId = @RoleId)");
            sqlStr.Append(" order by m.ParentId,m.Sort,b.Sort");
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, sqlStr.ToString(), new SqlParameter("@RoleId", roleId));
        }

        /// <summary>
        /// 根据用户主键id查询用户拥有的权限（后台首页“我的权限”）
        /// </summary>
        public DataTable GetMyAuthority(int id)
        {
            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.StoredProcedure, "sp_GetAuthorityByUserId", new SqlParameter("@userId", id));
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddMenu(ZGZY.Model.Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbMenu(");
            strSql.Append("Name,ParentId,Code,LinkAddress,Icon,Sort,AddDate");
            strSql.Append(") values (");
            strSql.Append("@Name,@ParentId,@Code,@LinkAddress,@Icon,@Sort,@AddDate");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@Name", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ParentId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@LinkAddress", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Icon", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Sort", SqlDbType.Int,4) ,            
                        new SqlParameter("@AddDate", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.Name;
            parameters[1].Value = model.ParentId;
            parameters[2].Value = model.Code;
            parameters[3].Value = model.LinkAddress;
            parameters[4].Value = model.Icon;
            parameters[5].Value = model.Sort;
            parameters[6].Value = model.AddDate;

            object obj = SqlHelper.GetSingle(strSql.ToString(), parameters);
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
        public bool UpdateMenu(ZGZY.Model.Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbMenu set ");

            strSql.Append(" Name = @Name , ");
            strSql.Append(" ParentId = @ParentId , ");
            strSql.Append(" Code = @Code , ");
            strSql.Append(" LinkAddress = @LinkAddress , ");
            strSql.Append(" Icon = @Icon , ");
            strSql.Append(" Sort = @Sort , ");
            strSql.Append(" AddDate = @AddDate  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Name", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ParentId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@LinkAddress", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Icon", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Sort", SqlDbType.Int,4) ,            
                        new SqlParameter("@AddDate", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.ParentId;
            parameters[3].Value = model.Code;
            parameters[4].Value = model.LinkAddress;
            parameters[5].Value = model.Icon;
            parameters[6].Value = model.Sort;
            parameters[7].Value = model.AddDate;
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
        public bool DeleteMenu(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbMenu ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


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
        public ZGZY.Model.Menu GetMenuModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, Name, ParentId, Code, LinkAddress, Icon, Sort, AddDate  ");
            strSql.Append("  from tbMenu ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


            ZGZY.Model.Menu model = new Model.Menu();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                if (ds.Tables[0].Rows[0]["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(ds.Tables[0].Rows[0]["ParentId"].ToString());
                }
                model.Code = ds.Tables[0].Rows[0]["Code"].ToString();
                model.LinkAddress = ds.Tables[0].Rows[0]["LinkAddress"].ToString();
                model.Icon = ds.Tables[0].Rows[0]["Icon"].ToString();
                if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
