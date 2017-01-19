using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Z.Framework.WorkBench.Network
{
    public class NetworkHelper
    {
        public static string GetLocalIpAddress()
        {
            var ipArray = Dns.GetHostAddresses(Dns.GetHostName()); string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }

            }
            if (AddressIP != string.Empty)
            {
                return AddressIP;
            }
            else
            {
                return "127.0.0.1";
            }
        }
    }
}