using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.Framework.Common;

namespace Z.Framework.BLL
{
    public class BasicOperation
    {
        DAL.BasicOperation dal = new DAL.BasicOperation();
        public ResultInfo GetConnection(string ip)
        {
            return dal.GetConnection(ip);
        }
    }
}
