using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Z.Framework.Workspace
{
    public class ReflexHelper
    {
        /// <summary>
        /// 反射文件路径
        /// </summary>
        public static string Path = Environment.CurrentDirectory + "\\Demo.dll";

        /// <summary>
        /// 反射类的命名空间+类名
        /// </summary>
        public static string InstanceName = "Demo.Page"; 


        /// <summary>
        /// 实例化反射到的页面，返回
        /// </summary>
        /// <param name="instanceName"></param>
        /// <returns></returns>
        public static UserControl IControllerInstance(string instanceName)
        {
            string className = Path+ instanceName;
            return (UserControl)Assembly.LoadFrom(Path).CreateInstance(instanceName);
        }
    }
}
