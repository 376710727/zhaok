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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Z.Framework.WorkBench
{
    /// <summary>
    /// SystemLoginPage.xaml 的交互逻辑
    /// </summary>
    public partial class SystemLoginPage : UserControl
    {
        public SystemLoginPage(Size size)
        {
            InitializeComponent();
            if (size != null)
            {
                this.Height = size.Height;
                this.Width = size.Width;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void AccountTb_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void AccountLogin(object sender, MouseButtonEventArgs e)
        {

        }

        private void ExitApp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
