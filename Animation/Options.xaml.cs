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
    /// Interaction logic for Options.xaml
    /// </summary>
    /// return (Keyboard.Key) Enum.Parse(typeof (Keyboard.Key), keystr);
    public partial class Options : UserControl
    {
        Canvas CanMenu;
        public Options()
        {
            InitializeComponent();
        }

        public Options(Canvas cmenu)
        {
            InitializeComponent();
            CanMenu = cmenu;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            string key = txt_shoot_key.Text;
            if(Key.LWin.ToString().Equals(key) || Key.Escape.ToString().Equals(key)
                || Key.CapsLock.ToString().Equals(key))
            {
                MessageBox.Show("Can not Use This Key!\nPlease, Choose Another Key.", "Invalid Key", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Properties.Settings.Default.SavedKeyShoot = key;
                Properties.Settings.Default.GameSpeed = slider.Value;
                Properties.Settings.Default.Save();
                btn_back_Click(null, null);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txt_shoot_key.Text = Properties.Settings.Default.SavedKeyShoot;
            slider.Value = Properties.Settings.Default.GameSpeed;
        }

        private void txt_shoot_key_KeyDown(object sender, KeyEventArgs e)
        {
            txt_shoot_key.Text = e.Key.ToString();
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            progress.Value = slider.Value;
        }

        private void progress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (progress.Value <= 1.5)
                progress.Foreground = Brushes.LightGreen;
            else if (progress.Value > 1.5 && progress.Value < 2.5)
                progress.Foreground = Brushes.Green;
            else
                progress.Foreground = Brushes.Red;
        }

        private void spaceKey_Click(object sender, RoutedEventArgs e)
        {
            txt_shoot_key.Text = Key.Space.ToString();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            CanMenu.Children.Remove(this);
        }
    }
}
