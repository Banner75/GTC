using System.Data;

namespace ZGZY.IDAL
{
    /// <summary>
    /// 按钮接口（不同的数据库访问类实现接口达到多数据库的支持）
    /// </summary>
    public interface IButton
    {
        /// <summary>
        /// 根据菜单标识码和用户id获取此用户拥有该菜单下的哪些按钮权限
        /// </summary>
        DataTable GetButtonByMenuCodeAndUserId(string menuCode, int userId);
        /// <summary>
        /// 判断按钮名称是否存在
        /// </summary>
        /// <param name="name">按钮名称</param>
        /// <returns></returns>
        bool checkButtonName(string name);
        /// <summary>
        /// 判断按钮标识码 是否存在
        /// </summary>
        /// <param name="name">标识码</param>
        /// <returns></returns>
        bool checkButtonCode(string Code);

        /// <summary>
        /// 新增按钮
        /// </summary>
        int addButton(ZGZY.Model.Button Button);


        /// <summary>
        /// 编辑按钮
        /// </summary>
        bool editButton(ZGZY.Model.Button Button);

        /// <summary>
        /// 删除按钮
        /// </summary>
        bool delButton(string  Buttonid);
        /// <summary>
        /// 获得按钮实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ZGZY.Model.Button getButtonModel(string id );
        /// <summary>
        /// 获得按钮列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataSet GetButtonList(string strWhere);


   
        

        

    }
}
