using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;


namespace Animation
{
    /// <summary>
    /// Interaction logic for PauseMenu.xaml
    /// </summary>
    public partial class PauseMenu : UserControl
    {
        MainWindow mainWindow;
        Canvas canvas;
        Menu menu;
        Rectangle rec;
        public PauseMenu()
        {
            InitializeComponent();
        }

        public PauseMenu(MainWindow mw , Canvas can , Menu _menu)
        {
            InitializeComponent();
            mainWindow = mw;
            canvas = can;
            menu = _menu;
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            Image btn = (Image)sender;
            btn.Source = new BitmapImage(new Uri(@"btn/" + btn.Name + ".png", UriKind.Relative));
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            Image btn = (Image)sender;
            btn.Source = new BitmapImage(new Uri(@"btn/" + btn.Name + "_1.png", UriKind.Relative));
        }

        private void ResumeGameing(object sender, MouseButtonEventArgs e)
        {
            canvas.Children.Remove(this);
            canvas.Children.Remove(rec);
            mainWindow.StartTimers();
            mainWindow.MenuIsActive = false;
        }

        private void GoToMenu(object sender, MouseButtonEventArgs e)
        {
           var r =  MessageBox.Show("Do You Need Save Your Score?", "Save ?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(r == MessageBoxResult.Yes)
                (new PlayerName("Go To Menu" , mainWindow.Scoure, mainWindow.level)).ShowDialog();
            mainWindow.Close();
        }

        private void Exit(object sender, MouseButtonEventArgs e)
        {
            var r = MessageBox.Show("Do You Need Save Your Score?", "Save ?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (r == MessageBoxResult.Yes)
                (new PlayerName("Good Bay!", mainWindow.Scoure, mainWindow.level)).ShowDialog();
            App.Current.Shutdown();
        }

        public string CurrentPlayerName { get; set; }

        public void Pause()
        {
            mainWindow.StopTimers();
            rec = new Rectangle();
            rec.Fill = Brushes.Black;
            rec.Opacity = 0.5;
            rec.Width = mainWindow.Width;
            rec.Height = mainWindow.Height;
            canvas.Children.Add(rec);
        }
    }
}
