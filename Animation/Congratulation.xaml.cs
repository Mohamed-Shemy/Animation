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

namespace Animation
{
    /// <summary>
    /// Interaction logic for Congratulation.xaml
    /// </summary>
    public partial class Congratulation : UserControl
    {
        Canvas canvas;
        MainWindow mainWindow;
        public Congratulation()
        {
            InitializeComponent();
        }

        public Congratulation(int level , Canvas can , MainWindow mw)
        {
            InitializeComponent();
            Level.Text = "Level   " +  level.ToString();
            canvas = can;
            mainWindow = mw;
            mainWindow.StopTimers();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Remove(this);
            mainWindow.StartTimers();
        }
    }
}
