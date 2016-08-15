using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ZGZY.Common;
using ZGZY.Model;

namespace ZGZY.SQLServerDAL
{
    /// <summary>
    /// 菜单（SQL Server数据库实现）
    /// </summary>
    public class MenuDA : ZGZY.IDAL.IMenuDA
    {
        #region 交易平台

        public List<SY_Menus> GetTradeMenus(int group)
        {
            List<SY_Menus> datas = new List<SY_Menus>();

            StringBuilder sql = new StringBuilder();
            sql.Append("select ");
            sql.Append("a.ID,a.Name,a.Caption,a.Parent as Parent_ID,a.Groups,a.Groups_Limn,a.Url,a.Action_Name,");
            sql.Append("a.Control_Name, a.Icon,a.Sort,a.Remark,b.Name as Parent_Name, b.Caption as Parent_Caption ");
            sql.Append("from SY_Menus a ");
            sql.Append("Left outer join SY_Menus b on a.Parent = b.ID ");
            sql.Append("Where ");
            sql.Append("a.Valid_State = 1 ");
            sql.Append("and a.Groups = @group ");
            sql.Append(" and a.Parent = 0 ");
            sql.Append("Order By a.Sort ");

            SqlParameter[] parameters = { 
                                        new SqlParameter("@group", group)
                                        };

            DataSet ds = SqlHelper.Query(sql.ToString(), parameters);
            if (ds != null || ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    SY_Menus data = new SY_Menus();
                    data.ID = (dr["ID"] == null) ? 0 : Convert.ToInt32(dr["ID"]);
                    data.Name = (dr["Name"] == null) ? "" : dr["Name"].ToString();
                    data.Caption = (dr["Caption"] == null) ? "" : dr["Caption"].ToString();
                    data.ParentID = (dr["Parent_ID"] == null) ? 0 : Convert.ToInt32(dr["Parent_ID"]);
                    data.ParentName = (dr["Parent_Name"] == null) ? "" : dr["Parent_Name"].ToString();
                    data.ParentCaption = (dr["Parent_Caption"] == null) ? "" : dr["Parent_Caption"].ToString();
                    data.Groups = (dr["Groups"] == null) ? 0 : Convert.ToInt32(dr["Groups"]);
                    data.Groups_Linm = (dr["Groups_Limn"] == null) ? "" : dr["Groups_Limn"].ToString();
                    data.Url = (dr["Url"] == null) ? "" : dr["Url"].ToString();
                    data.ActionName = (dr["Action_Name"] == null) ? "" : dr["Action_Name"].ToString();
                    data.ControlName = (dr["Control_Name"] == null) ? "" : dr["Control_Name"].ToString();
                    data.Icon = (dr["Icon"] == null) ? "" : dr["Icon"].ToString();
                    data.Sort = (dr["Sort"] == null) ? 0 : Convert.ToInt32(dr["Sort"]);
                    data.Remark = (dr["Remark"] == null) ? "" : dr["Remark"].ToString();
                    datas.Add(data);
                }
            }
            else
            {
                datas = null;
            }

            return datas;
        }

        #endregion

        #region 会员管理

        #region 读取菜单

        /// <summary>
        /// 根居角色号，分组号读取菜单
        /// </summary>
        /// <param name="role">角色号</param>
        /// <param name="group">分组号</param>
        /// <param name="isTop">是否顶级菜单</param>
        /// <returns>菜单项</returns>
        public List<SY_Menus> GetHomeMenus(int role, int group, bool isTop)
        {
            List<SY_Menus> datas = new List<SY_Menus>();

            StringBuilder sql = new StringBuilder();
            sql.Append("select ");
            sql.Append("a.ID,a.Name,a.Caption,a.Parent as Parent_ID,a.Groups,a.Groups_Limn,a.Url,a.Action_Name,");
            sql.Append("a.Control_Name, a.Icon,a.Sort,a.Remark,b.Name as Parent_Name, b.Caption as Parent_Caption ");
            sql.Append("from SY_Menus a ");
            sql.Append("Left outer join SY_Menus b on a.Parent = b.ID ");
            sql.Append("inner join SY_Role_Menus c on a.ID = c.Menu_ID ");
            sql.Append("Where ");
            sql.Append("a.Valid_State = 1 ");
            sql.Append("and c.Role_ID = @roleid ");
            sql.Append("and a.Groups = @group ");
            if (isTop)
            {
                sql.Append(" and a.Parent = 0 ");
            }
            else
            {
                sql.Append(" and a.Parent <> 0 ");
            }
            sql.Append("Order By a.Sort ");

            SqlParameter[] parameters = { 
                                        new SqlParameter("@roleid",role),
                                        new SqlParameter("@group", group)
                                        };

            DataSet ds = SqlHelper.Query(sql.ToString(), parameters);
            if (ds != null || ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    SY_Menus data = new SY_Menus();
                    data.ID = (dr["ID"] == null) ? 0 : Convert.ToInt32(dr["ID"]);
                    data.Name = (dr["Name"] == null) ? "" : dr["Name"].ToString();
                    data.Caption = (dr["Caption"] == null) ? "" : dr["Caption"].ToString();
                    data.ParentID = (dr["Parent_ID"] == null) ? 0 : Convert.ToInt32(dr["Parent_ID"]);
                    data.ParentName = (dr["Parent_Name"] == null) ? "" : dr["Parent_Name"].ToString();
                    data.ParentCaption = (dr["Parent_Caption"] == null) ? "" : dr["Parent_Caption"].ToString();
                    data.Groups = (dr["Groups"] == null) ? 0 : Convert.ToInt32(dr["Groups"]);
                    data.Groups_Linm = (dr["Groups_Limn"] == null) ? "" : dr["Groups_Limn"].ToString();
                    data.Url = (dr["Url"] == null) ? "" : dr["Url"].ToString();
                    data.ActionName = (dr["Action_Name"] == null) ? "" : dr["Action_Name"].ToString();
                    data.ControlName = (dr["Control_Name"] == null) ? "" : dr["Control_Name"].ToString();
                    data.Icon = (dr["Icon"] == null) ? "" : dr["Icon"].ToString();
                    data.Sort = (dr["Sort"] == null) ? 0 : Convert.ToInt32(dr["Sort"]);
                    data.Remark = (dr["Remark"] == null) ? "" : dr["Remark"].ToString();
                    datas.Add(data);
                }
            }
            else
            {
                datas = null;
            }

            return datas;
        }

        #endregion

        #endregion
    }
}
