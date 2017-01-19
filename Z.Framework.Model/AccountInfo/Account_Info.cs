using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z.Framework.Model
{
    /// <summary>
    /// 用户基本信息
    /// </summary>
    public class Account_Info
    {
        public string Account { set; get; }
        public string Password
        {
            set
            {
                if(value == string.Empty)
                {
                    throw new Exception("密码不能为空");
                }
                Md5Password = Common.Utilities.Md5(value);
            }
        }
        public string Md5Password
        {
            private set;
            get;
        }

        /// <summary>
        /// 登录凭证
        /// </summary>
        public string Session { set; get; }
        /// <summary>
        /// 凭证过期时间
        /// </summary>
        public DateTime? SessionOffTime { set; get; }

        public bool LoginState { set; get; }

        public DateTime? LoginTime { set; get; }

        public DateTime? LogoutTime { set; get; }
    }
}
