using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Z.Framework.Common;

namespace Z.Framework.DAL
{
    public class BasicOperation
    {
        DbEntity.zEntity Db = new DbEntity.zEntity();
        ResultInfo rst = new ResultInfo();
        public ResultInfo GetConnection()
        {
            var ip = "127.0.0.0";
            return GetConnection(ip);

        }
        public ResultInfo GetConnection(string ip)
        {
            try
            {
                var count = Db.T_ACCOUNT.Count();
                if (ip != string.Empty)
                {

                }
                rst.IsSuccessed = true;
                return rst;
            }
            catch(Exception ex)
            {
                rst.IsSuccessed = false;
                rst.ErrorText = ex.Message;
                return rst;
            }

        }
    }
}
