using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using Z.Framework.Workspace;

namespace Z.Framework.WorkBench
{
    /// <summary>
    /// SystemPreparing.xaml 的交互逻辑
    /// </summary>
    public partial class SystemPreparing : Window
    {
        public const string SoftwareName = "WMS";

        public delegate void SysBusyDelegate(bool isbusy,bool value,string msg);
        public event SysBusyDelegate SysbusyEvent;
        public SystemPreparing()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.Duration = new Duration(TimeSpan.FromSeconds(1));
            da.To = 180d;

            this.axr.BeginAnimation(AxisAngleRotation3D.AngleProperty, da);

            var thread = new Thread(new System.Threading.ThreadStart(() =>
            {
                // mack connection
                Thread.Sleep(1000);
                var localIp = Network.NetworkHelper.GetLocalIpAddress();
                try
                {
                    var rst = new zService.ServiceClient().GetConnection(localIp);
                    if (!rst)
                    {
                        SysbusyEvent.Invoke(false,false, "连接服务器失败，请检查您的网络!");
                    }
                    else
                    {
                        SysbusyEvent.Invoke(false, true, "连接成功!");
                    }
                }
                catch(Exception ex)
                {
                    SysbusyEvent.Invoke(false,false,ex.Message);
                }                
               
            }))

            { IsBackground = true};
            thread.Start();
            SysbusyEvent += (state,value,msg) =>
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (state == false)
                    {
                        if (value)
                        {
                            StatusLb.Text = msg;
                        }
                        else
                        {
                            MessageBox.Show(msg);
                            App.Current.Shutdown(1);
                        }
                        var workspace = new SystemFramework();
                        workspace.Show();
                        this.Close();                        
                    }

                }));
            };

        }
    }
}
