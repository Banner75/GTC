using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZGZY.Model
{
    public class Message
    {


        /// <summary>
        /// ID
        /// </summary>		
        private string _id;
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 标题
        /// </summary>		
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// 内容
        /// </summary>		
        private string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>		
        private DateTime _createdate;
        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
        /// <summary>
        /// 1.未回复 2.已回复
        /// </summary>		
        private int _state;
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
        /// <summary>
        /// 用户名
        /// </summary>		
        private string _login_account;
        public string Login_Account
        {
            get { return _login_account; }
            set { _login_account = value; }
        }
        /// <summary>
        /// 回复内容
        /// </summary>		
        private string _reply;
        public string Reply
        {
            get { return _reply; }
            set { _reply = value; }
        }
        /// <summary>
        /// 回复时间
        /// </summary>		
        private DateTime _replydate;
        public DateTime ReplyDate
        {
            get { return _replydate; }
            set { _replydate = value; }
        }
        /// <summary>
        /// 1.账号问题 2.业务问题 3.财务问题 4.其它问题
        /// </summary>		
        private int _type;
        public int Type
        {
            get { return _type; }
            set { _type = value; }


        }
    }
}
