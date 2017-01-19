using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Z.Framework.Common
{
    public class Utilities
    {
        public static string Md5(string text)
        {
            byte[] result = new MD5CryptoServiceProvider().ComputeHash(System.Text.Encoding.Default.GetBytes(text));
            var md5 = "";
            foreach (var b in result)
            {
                md5 += b.ToString("X2");
            }
            return md5.ToLower();
        }

        public static string GetRandomCode(int bytes = 4)
        {
            var rand = new Random();
            var code = "";
            for (int i = 0; i < bytes; i++)
            {
                code += rand.Next(256).ToString("X2");
            }
            return code.ToLower();
        }

        #region Serializer

       // private static int DefaultTime = 300000;

        //private static int _Timeout = -1;

        private static int Timeout = 300000;
        //private static int Timeout
        //{
        //    get
        //    {
        //        if (_Timeout == -1)
        //        {
        //            var setting = System.Configuration.ConfigurationManager.AppSettings["Timeout"];
        //            if (string.IsNullOrEmpty(setting))
        //            {
        //                _Timeout = DefaultTime;
        //            }
        //            else
        //            {
        //                int timeout;
        //                if (int.TryParse(setting, out timeout) && timeout > 0)
        //                {
        //                    _Timeout = timeout;
        //                }
        //                else
        //                {
        //                    _Timeout = DefaultTime;
        //                }
        //            }
        //        }
        //        return _Timeout;
        //    }
        //}

        public static T Post<T>(string url, Dictionary<string, string> kvs)
        {
            var data = "";
            foreach (var k in kvs.Keys)
            {
                if (string.IsNullOrEmpty(data))
                {
                    data += k + "=" + kvs[k];
                }
                else
                {
                    data += "&" + k + "=" + kvs[k];
                }
            }

            HttpWebRequest rq = null;

            try
            {
                rq = WebRequest.Create(url) as HttpWebRequest;
            }
            catch (Exception e) { throw new Exception("WEBSERVICE地址无效", e); }

            rq.Timeout = Timeout;
            rq.Method = "POST";
            rq.ContentType = "application/x-www-form-urlencoded";

            byte[] bs = Encoding.UTF8.GetBytes(data);
            rq.ContentLength = bs.Length;
            try
            {
                using (Stream writer = rq.GetRequestStream())
                {
                    if (bs.Length > 0)
                    {
                        writer.Write(bs, 0, bs.Length);
                    }
                }
            }
            catch (Exception e) { throw new Exception("发送失败，网络异常", e); }

            var response = "";
            try
            {
                var rp = rq.GetResponse() as HttpWebResponse;

                using (Stream reader = rp.GetResponseStream())
                {
                    response = new StreamReader(reader, Encoding.UTF8).ReadToEnd();
                }
            }
            catch (Exception e) { throw new Exception("接收失败，网络异常", e); }

            try
            {
                return Deserialize<T>(TrimServiceXmlns(response), false);
            }
            catch (Exception e) { throw new Exception("数据序列化异常", e); }
        }

        private static string TrimServiceXmlns(string xml) { return xml.Replace("xmlns=\"http://zSystem.com/\"", ""); }

        public static string Serialize<T>(T entity, bool base64 = true)
        {

            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(sw, entity);

                if (base64)
                {
                    return Convert.ToBase64String(Encoding.UTF8.GetBytes(sw.ToString()));
                }
                else
                {
                    return sw.ToString();
                }
            }
        }
        public static T Deserialize<T>(string data, bool base64 = true)
        {
            if (base64)
            {
                data = Encoding.UTF8.GetString(Convert.FromBase64String(data.Replace(" ", "+")));
            }

            try
            {
                using (System.IO.StringReader sr = new System.IO.StringReader(data))
                {
                    var deserializer = new XmlSerializer(typeof(T));
                    return (T)deserializer.Deserialize(sr);
                }
            }
            catch (Exception) { return default(T); }
        }

        #endregion
    }
}
