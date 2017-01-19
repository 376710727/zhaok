using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Z.Framework.Common;
using Z.Framework.Model;

namespace Z.Framework.Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class ZService : IService
    {
        BLL.BasicOperation bll = new BLL.BasicOperation();
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }

            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        /* 接口实现*/
        public bool GetConnection(string data)
        {
            //xml method
            var rst = bll.GetConnection(data);
            if (rst.IsSuccessed)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public ResultInfo LoginByPassword(Account_Info user)
        {
            var bll = new BLL.SignOperation();
            try
            {
                var rst = bll.LoginByPassword(user);
                return rst;
            }
            catch (Exception ex)
            {
                return new ResultInfo() { IsSuccessed = false, ErrorText = ex.Message };
            }
        }
    }
}
