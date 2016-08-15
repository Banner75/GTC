using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcWeb
{
    public class DigIncomeDetaiModel
    {
        /// <summary>
        /// 矿币列表
        /// </summary>
        public DataTable IncomeList { get; set; }
        /// <summary>
        /// PC分页
        /// </summary>
        public PageModel PageModel { get; set; }
    }
}