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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Z.Framework.WorkBench.Tools
{
    /// <summary>
    /// ProgressBar.xaml 的交互逻辑
    /// </summary>
    public partial class ProgressBar : UserControl
    {
        public ProgressBar()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            double width = 0;
            if (this.ActualWidth != 0) { width = this.ActualWidth; }
            else if (!double.IsNaN(this.Width)) { width = this.Width; }

            var storyboard = new Storyboard()
            {
                RepeatBehavior = RepeatBehavior.Forever
            };
            ThicknessAnimationUsingKeyFrames a1 = new ThicknessAnimationUsingKeyFrames();
            var a11 = new SplineThicknessKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.6)),
                Value = new Thickness(0.48 * width, 0, 0, 0)
            };
            a1.KeyFrames.Add(a11);
            var a12 = new SplineThicknessKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1.4)),
                Value = new Thickness(0.55 * width, 0, 0, 0)
            };
            a1.KeyFrames.Add(a12);
            var a13 = new SplineThicknessKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2)),
                Value = new Thickness(width, 0, 0, 0)
            };
            a1.KeyFrames.Add(a13);

            ThicknessAnimationUsingKeyFrames a2 = new ThicknessAnimationUsingKeyFrames();
            var a22 = new SplineThicknessKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.9)),
                Value = new Thickness(0.48 * width, 0, 0, 0)
            };
            a2.KeyFrames.Add(a22);
            var a23 = new SplineThicknessKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1.7)),
                Value = new Thickness(0.55 * width, 0, 0, 0)
            };
            a2.KeyFrames.Add(a23);
            var a24 = new SplineThicknessKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2.2)),
                Value = new Thickness(width, 0, 0, 0)
            };
            a2.KeyFrames.Add(a24);

            ThicknessAnimationUsingKeyFrames a3 = new ThicknessAnimationUsingKeyFrames();
            var a32 = new SplineThicknessKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1.2)),
                Value = new Thickness(0.48 * width, 0, 0, 0)
            };
            a3.KeyFrames.Add(a32);
            var a33 = new SplineThicknessKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2.0)),
                Value = new Thickness(0.55 * width, 0, 0, 0)
            };
            a3.KeyFrames.Add(a33);
            var a34 = new SplineThicknessKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2.4)),
                Value = new Thickness(width, 0, 0, 0)
            };
            a3.KeyFrames.Add(a34);

            ThicknessAnimationUsingKeyFrames a4 = new ThicknessAnimationUsingKeyFrames();
            var a42 = new SplineThicknessKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1.5)),
                Value = new Thickness(0.48 * width, 0, 0, 0)
            };
            a4.KeyFrames.Add(a42);
            var a43 = new SplineThicknessKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2.3)),
                Value = new Thickness(0.54 * width, 0, 0, 0)
            };
            a4.KeyFrames.Add(a43);
            var a44 = new SplineThicknessKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2.6)),
                Value = new Thickness(width, 0, 0, 0)
            };
            a4.KeyFrames.Add(a44);

            Storyboard.SetTarget(a1, e1);
            Storyboard.SetTargetProperty(a1, new PropertyPath("(FrameworkElement.Margin)"));
            Storyboard.SetTarget(a2, e2);
            Storyboard.SetTargetProperty(a2, new PropertyPath("(FrameworkElement.Margin)"));
            Storyboard.SetTarget(a3, e3);
            Storyboard.SetTargetProperty(a3, new PropertyPath("(FrameworkElement.Margin)"));
            Storyboard.SetTarget(a4, e4);
            Storyboard.SetTargetProperty(a4, new PropertyPath("(FrameworkElement.Margin)"));

            storyboard.Children.Add(a1);
            storyboard.Children.Add(a2);
            storyboard.Children.Add(a3);
            storyboard.Children.Add(a4);

            storyboard.Begin();
        }

    }
}
