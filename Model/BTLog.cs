using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZGZY.Model
{
   public class BTLog
    {
        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// type
        /// </summary>		
        private int _type;
        public int type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// state
        /// </summary>		
        private int _state;
        public int state
        {
            get { return _state; }
            set { _state = value; }
        }
        /// <summary>
        /// logcontent
        /// </summary>		
        private string _logcontent;
        public string logcontent
        {
            get { return _logcontent; }
            set { _logcontent = value; }
        }
        /// <summary>
        /// addtime
        /// </summary>		
        private DateTime _addtime;
        public DateTime addtime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }
        /// <summary>
        /// userID
        /// </summary>		
        private string _userid;
        public string userID
        {
            get { return _userid; }
            set { _userid = value; }
        }

        /// <summary>
        /// btmoney
        /// </summary>		
        private decimal _btmoney;
        public decimal btmoney
        {
            get { return _btmoney; }
            set { _btmoney = value; }
        }        
    }
}
