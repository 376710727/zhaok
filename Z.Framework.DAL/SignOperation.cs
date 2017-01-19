using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.Framework.Common;
using Z.Framework.Model;

namespace Z.Framework.DAL
{
    /// <summary>
    /// 登入、登出
    /// </summary>
    public class SignOperation
    {
        
        DbEntity.zEntity Db = new DbEntity.zEntity();
        ResultInfo rst = new ResultInfo();
        public ResultInfo LoginByPassword(Account_Info user)
        {
            var rst = new ResultInfo();
            if (Db.T_ACCOUNT.Count(x=>x.Account_Name == user.Account) < 0) //no such username
            {
                rst.IsSuccessed = false;rst.ErrorText = "用户名不存在";
                return rst;
            }
            else if(Db.T_ACCOUNT.Count(x => x.Account_Name == user.Account &&x.Account_Pwd == user.Md5Password) < 0) // error password
            {
                rst.IsSuccessed = false; rst.ErrorText = "您输入的密码错误";
                return rst;
            }
            else
            {
                rst.IsSuccessed = true;
                return rst;
            }
        }
    }
}
