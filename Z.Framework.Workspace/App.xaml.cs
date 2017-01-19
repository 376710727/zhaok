using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Z.Framework.Workspace
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private System.Timers.Timer Timer { set; get; }
        private DateTime CurrentTime { set; get; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.DispatcherUnhandledException += App_DispatcherUnhandledException;

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Timer = new System.Timers.Timer(1000);
            Timer.Elapsed += (s, a) => { CurrentTime = DateTime.Now;  };
            Timer.Enabled = true;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //Log it
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("系统检测到部分未处理异常,即将关闭。若问题始终存在，请联系软件供应商，给您带来的不便深表歉意!", "警告");

            Application.Current.Shutdown(1);
        }

      
    }
}
