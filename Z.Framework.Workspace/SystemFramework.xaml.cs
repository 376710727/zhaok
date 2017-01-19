using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Z.Framework.Model;
using Z.Framework.WorkBench.Tools;

namespace Z.Framework.WorkBench
{
    /// <summary>
    /// SystemFramework.xaml 的交互逻辑
    /// </summary>
    public partial class SystemFramework : Window
    {
        #region Delegates

        #endregion

        #region ViewModels
        private Account_Info UserInfo { set; get; }
        #endregion
        public SystemFramework()
        {
            InitializeComponent();

            #region 获取windows缩放比例
            using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromHwnd(IntPtr.Zero))
            {
                float dpiX = graphics.DpiX;
                float dpiY = graphics.DpiY;
                switch (Convert.ToInt32(dpiX))
                {
                    case 96:
                        DPIAdpter.Zoom = 1;
                        break;
                    case 120:
                        DPIAdpter.Zoom = 1.25;
                        break;
                    case 144:
                        DPIAdpter.Zoom = 1.5;
                        break;
                    case 192:
                        DPIAdpter.Zoom = 2;
                        break;
                    default:
                        DPIAdpter.Zoom = 1;
                        break;
                }
            }
            if (SystemParameters.PrimaryScreenWidth < 1360 || SystemParameters.PrimaryScreenHeight < 760)
            {
                if (SystemParameters.PrimaryScreenWidth * DPIAdpter.Zoom > 1360
                    && SystemParameters.PrimaryScreenHeight * DPIAdpter.Zoom > 760)
                {
                    //实际分辨率足够 ，缩放的太大了
                    MessageBox.Show("您目前的缩放比例过大,\r请在显示设置中调整缩放比例，\r系统即将退出！");
                }
                else
                {
                    MessageBox.Show("您的分辨率过小，\r无法达到系统最低要求，\r系统将退出！");
                }

                Application.Current.Shutdown(1);
            }

            #endregion
        }

        void Login()
        {
            var size = new Size()
            {
                Height = this.ActualHeight - 50,
                Width = MainPanel.ActualWidth,
            };
            var l = new SystemLoginPage(size);
           // l.login += L_login;
            MainPanel.Children.Add(l);
            //LogoutAnimation();
            //if (NeedLogin)
            //{

            //}
           // else
            //{
                //User.Uid = 1;
               // User.IsLogin = true;
                //LoginAnimation();
           // }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            #region 登录注销事件

            if (UserInfo == null || UserInfo.LoginState != true)
            {

                Login();

            }
            #endregion
        }

        #region 窗体边框、缩放、最大最小化、拖拽事件
        public Point Mypoint; //窗体坐标
        public Size Mysize; //窗体大小

        bool normalState = true;
        Rect rcnormal;//定义一个全局rect记录还原状态下窗口的位置和大小。

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.ActualHeight > SystemParameters.WorkArea.Height || this.ActualWidth > SystemParameters.WorkArea.Width)
            {
                this.WindowState = System.Windows.WindowState.Normal;
                WindowMaximize();
            }

            if (MainPanel.Children != null && MainPanel.Children.Count > 0)
            {
                foreach(var child in MainPanel.Children)
                {
                    if(child is SystemLoginPage)
                    {
                        (child as SystemLoginPage).Width = this.Width;
                        (child as SystemLoginPage).Height = this.Height - 50;
                    }
                }
               
            }
        }
        /// <summary>
        /// 最大化
        /// </summary>
        private void WindowMaximize()
        {
            this.BorderThickness = new Thickness(0);
            rcnormal = new Rect(this.Left, this.Top, this.Width, this.Height);//保存下当前位置与大小
            this.Left = 0;//设置位置
            this.Top = 0;
            Rect rc = SystemParameters.WorkArea;//获取工作区大小
            this.Width = rc.Width;
            this.Height = rc.Height;
            normalState = false;
        }
        /// <summary>
        /// 还原
        /// </summary>
        private void WindowNormal(bool maxwindowDrag)
        {
            if (maxwindowDrag)
            {

                this.Left = 0;
                this.Top = 0;
                this.Width = rcnormal.Width;
                this.Height = rcnormal.Height;
                normalState = true;
                this.BorderThickness = new Thickness(1);
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            }


            else
            {
                this.Left = rcnormal.Left;
                this.Top = rcnormal.Top;
                this.Width = rcnormal.Width;
                this.Height = rcnormal.Height;
                normalState = true;
                this.BorderThickness = new Thickness(1);
            }

        }
        private void Shutdown(object sender, MouseButtonEventArgs e)
        {

            if (MessageBox.Show("提醒", "您确定要退出吗?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void MinimizWindow(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ChangeWindowState(object sender, MouseButtonEventArgs e)
        {
            if (!normalState)
            {

                WindowNormal(false);
                Mypoint = this.PointToScreen(new Point());
                Mysize = new Size(this.Width, this.Height);
            }
            else
            {

                WindowMaximize();
                Mypoint = this.PointToScreen(new Point());
                Mysize = new Size(this.Width, this.Height);
            }
        }


        private DateTime? LastMouseDownTimeInHeaderBar { get; set; }
        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (LastMouseDownTimeInHeaderBar != null && (DateTime.Now - LastMouseDownTimeInHeaderBar) < TimeSpan.FromSeconds(0.3))
            {
                if (!normalState)
                {
                    WindowNormal(false);
                    Mypoint = this.PointToScreen(new Point());
                    Mysize = new Size(this.Width, this.Height);
                }
                else
                {
                    WindowMaximize();
                    Mypoint = this.PointToScreen(new Point());
                    Mysize = new Size(this.Width, this.Height);
                }
                return;
            }
            else
            {
                LastMouseDownTimeInHeaderBar = DateTime.Now;
            }

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (normalState)//原大情况下是拖拽
                {

                    this.DragMove();
                    Mypoint = this.PointToScreen(new Point());
                    Mysize = new Size(this.Width, this.Height);
                }
                else //最大化时先缩小 再拖拽
                {
                    //p1 = Mouse.GetPosition(e.Source as FrameworkElement);

                    dragTimer.Interval = TimeSpan.FromMilliseconds(50);
                    dragTimer.Tick += DragTimer_Tick;
                    dragTimer.Start();
                }

            }
        }

        private void DragTimer_Tick(object sender, EventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                WindowNormal(true);
                Mypoint = this.PointToScreen(new Point());
                Mysize = new Size(this.Width, this.Height);
            }
            dragTimer.Stop();
        }


        DispatcherTimer dragTimer = new DispatcherTimer();

       


        #endregion

        private void HideChildNode(object sender, MouseEventArgs e)
        {

        }

        private void StackPanelShowScorBar(object sender, SizeChangedEventArgs e)
        {

        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void NailChildNodes(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
