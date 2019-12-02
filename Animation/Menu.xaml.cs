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
using WPF.MDI;

namespace Animation
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void StartNewGame(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            (new MainWindow(this , 1)).Show();
        }

        private void ButtonsMuoseUp(object sender , MouseEventArgs e)
        {
            Image btn = (Image)sender;
            btn.Source = new BitmapImage(new Uri(@"btn/" + btn.Name + "_1.png", UriKind.Relative));
        }

        private void ButtonsMuoseDown(object sender, MouseEventArgs e)
        {
            Image btn = (Image)sender;
            btn.Source = new BitmapImage(new Uri(@"btn/" + btn.Name + ".png", UriKind.Relative));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void btn_exit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btn_options_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainCanvas.Children.Add(new Options(MainCanvas) { Width = 285, Height = 230 });
        }

        private void btn_players_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainCanvas.Children.Add(new PlayersList(MainCanvas) { Width = 285, Height = 230 });
        }
    }
}
