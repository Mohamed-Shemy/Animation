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
using System.Windows.Media.Animation;
using System.Threading;

namespace Animation
{
    /// <summary>
    /// Interaction logic for StartUp.xaml
    /// </summary>
    public partial class StartUp : Window
    {
        public StartUp()
        {
            InitializeComponent();
        }
        DispatcherTimer timer;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += Timer_Tick;
            timer.IsEnabled = true;

            DoubleAnimation rocket = new DoubleAnimation(10, 2000, TimeSpan.FromSeconds(6));
            DoubleAnimation text = new DoubleAnimation(10, 2000, TimeSpan.FromSeconds(6));
            rocket.Completed += delegate
            {
                DoubleAnimation b = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(1));
                DoubleAnimation ex = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(1));
                timer.IsEnabled = false;
                b.Completed += delegate
                {
                    DoubleAnimation fi = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(1));
                    fi.Completed += delegate
                    {
                        Thread.Sleep(2000);
                        this.Hide();
                        (new Menu()).Show();
                    };
                    boom.BeginAnimation(OpacityProperty, fi);
                };
                earth.BeginAnimation(OpacityProperty, ex);
                boom.BeginAnimation(OpacityProperty, b);
            };
            msh.BeginAnimation(WidthProperty, text);
            war.BeginAnimation(LeftProperty, rocket);
        }

        int angle = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            RotateTransform rt = new RotateTransform(angle++, 150, 150);
            earth.RenderTransform = rt;
        }
    }
}
