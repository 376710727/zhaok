using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z.Framework.WorkBench
{
    public static class Utilities
    {
        public static T2 VisitWebService<T1,T2>(T1 dataObj,string serviceName)
        {
            try
            {
                var data = new Dictionary<string, string>();
                data.Add("session", "");
                data.Add("data", Common.Utilities.Serialize<T1>(dataObj));

                return Common.Utilities.Post<T2>(System.Configuration.ConfigurationManager.AppSettings["ServiceUrl"] + "/" + serviceName, data);
            }
            catch(Exception ex)
            {
                //Log it 
                throw;
            }
        }
    }
}
