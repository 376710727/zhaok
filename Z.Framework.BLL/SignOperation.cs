using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.Framework.Common;
using Z.Framework.Model;

namespace Z.Framework.BLL
{
    
    public class SignOperation
    {
        DAL.SignOperation dal = new DAL.SignOperation();
        ResultInfo rst = new ResultInfo();

        public ResultInfo LoginByPassword(Account_Info user)
        {
            if (user == null)
            {
                rst.IsSuccessed = false;
                rst.ErrorText = "数据异常，读取的账户信息为空！";
                return rst;
            }
            else if (user.Account == string.Empty || user.Md5Password == string.Empty)
            {
                rst.IsSuccessed = false;
                rst.ErrorText = "数据异常，用户名或密码为空！";
                return rst;
            }
            else
            {
                return dal.LoginByPassword(user);
            }           
        }
    }
}
