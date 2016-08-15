﻿/**  版本信息模板在安装目录下，可自行修改。
* BS_Configuration.cs
*
* 功 能： N/A
* 类 名： BS_Configuration
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/9 9:48:14   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace ZGZY.Model
{
    /// <summary>
    /// BS_Configuration:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class BS_Configuration
    {
        public BS_Configuration()
        { }
        #region Model
        private int _id;
        private string _nmae;
        private string _value;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Nmae
        {
            set { _nmae = value; }
            get { return _nmae; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string value
        {
            set { _value = value; }
            get { return _value; }
        }
        #endregion Model

    }
}
