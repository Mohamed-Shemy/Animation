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
using System.Windows.Threading;
using System.Threading;

namespace Animation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double GunAngle = 0;
        double RockAngle = 0;
        public double Scoure = 0;
        int OneSec = 0;
        int ShWait = 0;
        double tmpScore = 0;
        public int level = 1;
        public Size size;
        double Speed = Properties.Settings.Default.GameSpeed;
        Key ShootKey =
            (Key)Enum.Parse(typeof(Key), Properties.Settings.Default.SavedKeyShoot);
        bool IsShoot = false;
        public bool MenuIsActive = false;
        bool IsMonsterLevel = false;


        DispatcherTimer attckTimer;
        DispatcherTimer bultsTimer;

        List<CImage> Bults = new List<CImage>();
        List<CImage> Rocks = new List<CImage>();
        Point WarshipLocation = new Point();
        private Menu menu;

        public MainWindow(Menu menu, int speed)
        {
            InitializeComponent();

            this.menu = menu;
            // Rocks Timer
            attckTimer = new DispatcherTimer();
            attckTimer.Interval = TimeSpan.FromMilliseconds(60 - (20 * (Speed - 1)));
            attckTimer.Tick += AttckTimer_Tick;
            attckTimer.IsEnabled = true;

            // Bults Timer
            bultsTimer = new DispatcherTimer();
            bultsTimer.Interval = TimeSpan.FromMilliseconds(60);
            bultsTimer.Tick += BultsTimer_Tick;
            bultsTimer.IsEnabled = true;

        }

        int increment = 1;
        private void BultsTimer_Tick(object sender, EventArgs e)
        {
            if (IsShoot && ShWait % 2 == 0)
            {
                Shoooooot();
                ShWait = 0;
            }
            ShWait++;
            for (int i = 0; i < Bults.Count; i++)
            {
                CImage img = Bults[i];
                //img.Angle = GunAngle;
                double x = Canvas.GetLeft(img);
                double y = Canvas.GetTop(img);
                x += 10 * Math.Sin(img.Angle * Math.PI / 180);
                y -= 10 * Math.Cos(img.Angle * Math.PI / 180);
                Canvas.SetTop(img, y);
                Canvas.SetLeft(img, x);

                Canvas.SetTop(img, Canvas.GetTop(img) - 10);
                for (int j = 0; j < Rocks.Count; j++)
                {
                    CImage r = Rocks[j];
                    if (Canvas.GetTop(img) - 5 <= Canvas.GetTop(r) + 20 &&
                             Canvas.GetTop(img) + 20 >= Canvas.GetTop(r))
                    {
                        if (Canvas.GetLeft(img) + img.Width / 2 >= Canvas.GetLeft(r) &&
                          Canvas.GetLeft(img) + img.Width / 2 <= Canvas.GetLeft(r) + r.Width)
                        {
                            Boom(Canvas.GetTop(r), Canvas.GetLeft(r), "boom");
                            Bults.Remove(img);
                            Rocks.Remove(r);
                            mainCanvas.Children.Remove(img);
                            mainCanvas.Children.Remove(r);
                            tb_score.Text = (++Scoure).ToString();
                        }
                    }
                }
                if (IsMonsterLevel)
                {
                    if ((Canvas.GetTop(img) - 10 <= Canvas.GetTop(monster) + monster.Height - 10) &&
                       (Canvas.GetTop(img) >= Canvas.GetTop(monster)) &&
                       Canvas.GetLeft(img) + img.Width >= Canvas.GetLeft(monster)
                       && (Canvas.GetLeft(img) - img.Width <= Canvas.GetLeft(monster) + monster.Width))
                    {
                        Boom(Canvas.GetTop(img), Canvas.GetLeft(img), "boom2");
                        Bults.Remove(img); mainCanvas.Children.Remove(img);
                        tb_score.Text = (Scoure += 5).ToString();
                        monsterLife.Value -= 1;
                    }
                }
                if (x <= -10 || x >=size.Width - 20)
                    img.Angle = 360 - img.Angle;

                if (Canvas.GetTop(img) <= 0)
                {
                    Bults.Remove(img);
                    mainCanvas.Children.Remove(img);
                }
            }
        }

        private void AttckTimer_Tick(object sender, EventArgs e)
        {
            WarshipLocation.X = Canvas.GetLeft(warship);
            WarshipLocation.Y = Canvas.GetTop(warship);

            if ((OneSec) % (20 - level) == 0 && !IsMonsterLevel)
            Attack();
            else if (IsMonsterLevel)
            {
                double left = Canvas.GetLeft(monster);
                if (left <= 0 || left >= size.Width - monster.Width + 10)
                    increment *= -1;
                Canvas.SetLeft(monster, left + increment);
                if (OneSec % 30 == 0)
                {
                    Bomb(left + 10);
                    Bomb(left + monster.Width - 10);
                }
            }
            OneSec++;
            for (int i = 0; i < Rocks.Count; i++)
            {
                CImage img = Rocks[i];
                //img.Angle = RockAngle;

                double x = Canvas.GetLeft(img);
                double y = Canvas.GetTop(img);
                x += 10 * Math.Sin(img.Angle * Math.PI / 180);
                y += 10 * Math.Cos(img.Angle * Math.PI / 180);
                Canvas.SetTop(img, y);
                Canvas.SetLeft(img, x);

                if (Canvas.GetTop(img) >= WarshipLocation.Y + 5)
                {
                    if (Canvas.GetLeft(img) + img.Width + 5 >= Canvas.GetLeft(warship) &&
                        Canvas.GetLeft(img) + (img.Width / 2) <= Canvas.GetLeft(warship) + warship.Width)
                    {
                        Rocks.Remove(img);
                        Boom(Canvas.GetTop(img), Canvas.GetLeft(img), "boom2");
                        mainCanvas.Children.Remove(img);
                        life.Value -= 20;
                        continue;
                    }
                }
                if (x <= 0 || x >= size.Width - 50)
                    img.Angle = 360 - img.Angle;
                if (Canvas.GetTop(img) >= size.Height - 50)
                {
                    Rocks.Remove(img);
                    mainCanvas.Children.Remove(img);
                }
            }
        }

        private void mainCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                if (e.Key == Key.Right)
                {
                    if (GunAngle <= 80)
                    {
                        GunAngle += 5;
                        RotateTransform rt = new RotateTransform(GunAngle - 2, 2, 29);
                        gun.RenderTransform = rt;
                    }
                }
                else if (e.Key == Key.Left)
                {
                    if (GunAngle >= -80)
                    {
                        GunAngle -= 5;
                        RotateTransform rt = new RotateTransform(GunAngle + 2, 2, 29);
                        gun.RenderTransform = rt;
                    }
                }
            }
            else if (Keyboard.IsKeyDown(ShootKey) || Keyboard.IsKeyDown(Key.Up))
            {
                IsShoot = true;
                if (e.Key == Key.Right)
                {
                    if (Canvas.GetLeft(warship) + warship.Width < Width)
                    {
                        double x = Canvas.GetLeft(warship) + 15;
                        Canvas.SetLeft(warship, x);
                    }
                    else
                        Canvas.SetLeft(warship, Width - warship.Width - 15);
                }
                else if (e.Key == Key.Left)
                {
                    if (Canvas.GetLeft(warship) >= 0)
                    {
                        double x = Canvas.GetLeft(warship) - 10;
                        Canvas.SetLeft(warship, x);
                    }
                }
            }
            else if (e.Key == Key.Right)
            {
                if (Canvas.GetLeft(warship) + warship.Width < Width)
                {
                    double x = Canvas.GetLeft(warship) + 15;
                    Canvas.SetLeft(warship, x);
                }
                else
                    Canvas.SetLeft(warship, Width - warship.Width - 15);
            }
            else if (e.Key == Key.Left)
            {
                if (Canvas.GetLeft(warship) >= 0)
                {
                    double x = Canvas.GetLeft(warship) - 10;
                    Canvas.SetLeft(warship, x);
                }
            }
            else if (e.Key == Key.Escape)
            {
                btn_menu_Click(null, null);
            }
        }

        private void Shoooooot()
        {
            CImage stone = new CImage();
            stone.Source = new BitmapImage(new Uri(@"img/target.png", UriKind.Relative));
            stone.Stretch = Stretch.Fill;
            stone.Angle = GunAngle;
            stone.Width = 20;
            Canvas.SetLeft(stone, Canvas.GetLeft(warship) + (warship.Width - stone.Width) / 2);
            Canvas.SetTop(stone, Canvas.GetTop(warship) - 20);
            mainCanvas.Children.Add(stone);
            Bults.Add(stone);
        }

        private void Bomb(double left)
        {
            Random ran = new Random();
            CImage bomb = new CImage();
            bomb.Source = new BitmapImage(new Uri(@"img/bomb.png", UriKind.Relative));
            bomb.Stretch = Stretch.Fill;
            bomb.Angle = ran.Next(-75, 75);
            bomb.Width = 30;
            Canvas.SetLeft(bomb, left);
            Canvas.SetTop(bomb, Canvas.GetTop(monster) + monster.Height - 10);
            RotateTransform rt = new RotateTransform(bomb.Angle);
            bomb.RenderTransform = rt;
            mainCanvas.Children.Add(bomb);
            Rocks.Add(bomb);
        }

        private void Attack()
        {
            CImage stone = new CImage();
            stone.Source = new BitmapImage(new Uri(@"img/ston.png", UriKind.Relative));
            stone.Stretch = Stretch.Fill;
            stone.Width = 40;
            Random ran = new Random();
            Canvas.SetLeft(stone, ran.Next(40, (int)(size.Width - 40)));
            stone.Angle = level > 1 ? ran.Next(-75, 75) : 0;
            Canvas.SetTop(stone, 1);
            mainCanvas.Children.Add(stone);
            Rocks.Add(stone);
        }

        private void Boom(double top, double left, string img)
        {
            Image boom = new Image();
            boom.Source = new BitmapImage(new Uri(@"img/" + img + ".png", UriKind.Relative));
            boom.Width = 70;
            mainCanvas.Children.Add(boom);
            Canvas.SetTop(boom, top);
            Canvas.SetLeft(boom, left);
            DoubleAnimation ooo = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(100));
            ooo.Completed += delegate
            {
                mainCanvas.Children.Remove(boom);
            };
            boom.BeginAnimation(OpacityProperty, ooo);
        }

        private void KileMonster(double top, double left, string img)
        {
            Image boom = new Image();
            boom.Source = new BitmapImage(new Uri(@"img/" + img + ".png", UriKind.Relative));
            boom.Width = 700;
            mainCanvas.Children.Add(boom);
            Canvas.SetTop(boom, -150);
            Canvas.SetLeft(boom, -150);
            tmpScore = Scoure;
            DoubleAnimation ooo = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(1000));
            ooo.Completed += delegate
            {
                mainCanvas.Children.Remove(boom);
            };
            boom.BeginAnimation(OpacityProperty, ooo);
        }

        private void mainCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (Canvas.GetLeft(warship) >= 0 && e.GetPosition(mainCanvas).X <= size.Width - warship.Width)
            {
                double x = e.GetPosition(mainCanvas).X;
                //double y = e.GetPosition(mainCanvas).Y;
                Canvas.SetLeft(warship, x);
                //Canvas.SetTop(warship, y);
            }
        }

        private void window_KeyUp(object sender, KeyEventArgs e)
        {
            IsShoot = false;
            ShWait = 0;
        }

        private void mainCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //IsShoot = true;
        }

        private void mainCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IsShoot = false;
            ShWait = 0;
        }

        private void life_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (life.Value == 40)
                life.Foreground = Brushes.Orange;
            else if (life.Value == 20)
                life.Foreground = Brushes.Red;
            else if (life.Value == 0)
            {
                attckTimer.IsEnabled = false;
                bultsTimer.IsEnabled = false;
                (new PlayerName("Game Over", Scoure, level)).ShowDialog();
                menu.Show();
                this.Close();
            }
        }
        
        private void tb_score_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Scoure - tmpScore == 100 && !IsMonsterLevel)
            {
                OneSec = 0;
                tmpScore = Scoure;
                level++;
                if (level % 5 == 0)
                    MonsterLevel();
                Congratulation con = new Congratulation(level, mainCanvas, this);
                mainCanvas.Children.Add(con);
                Canvas.SetTop(con, 100);
                RockAngle = (RockAngle + 5) % 75;
                attckTimer.Interval = TimeSpan.FromMilliseconds(60 - (20 * (Speed - 1) + level));
            }
        }

        private void MonsterLevel()
        {
            StopTimers();
            foreach (CImage img in Rocks)
                mainCanvas.Children.Remove(img);
            foreach (CImage img in Bults)
                mainCanvas.Children.Remove(img);
            Rocks.Clear();
            Bults.Clear();
            IsMonsterLevel = true;
            monster.Opacity = 1;
            monsterLife_Loaded(null, null);
            DoubleAnimation down = new DoubleAnimation(-188, 55, TimeSpan.FromSeconds(3));
            monster.BeginAnimation(TopProperty, down);
        }

        private void btn_menu_Click(object sender, RoutedEventArgs e)
        {
            if (!MenuIsActive)
            {
                MenuIsActive = true;
                PauseMenu pause = new PauseMenu(this, mainCanvas, menu);
                Canvas.SetTop(pause, 200);
                Canvas.SetLeft(pause, 50);
                pause.Width = 300;
                pause.Pause();
                mainCanvas.Children.Add(pause);
            }
        }

        private void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                menu.Show();
            }
            catch (Exception ex) { }
        }

        private void window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IsShoot = false;
            ShWait = 0;
        }

        private void window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IsShoot = true;
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            Congratulation con = new Congratulation(1, mainCanvas, this);
            mainCanvas.Children.Add(con);
            Canvas.SetTop(con, 100);
        }

        public void StopTimers()
        {
            bultsTimer.IsEnabled = false;
            attckTimer.IsEnabled = false;
        }

        public void StartTimers()
        {
            bultsTimer.IsEnabled = true;
            attckTimer.IsEnabled = true;
        }

        private void monsterLife_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double m = monsterLife.Value;
            if (m <= 40 && m > 20)
                monsterLife.Foreground = Brushes.Orange;
            else if (m <= 20 && m > 0)
                monsterLife.Foreground = Brushes.Red;
            else if (m <= 0)
            {
                StopTimers();
                foreach (CImage img in Rocks)
                    mainCanvas.Children.Remove(img);
                foreach (CImage img in Bults)
                    mainCanvas.Children.Remove(img);
                Rocks.Clear();
                Bults.Clear();
                KileMonster(Canvas.GetTop(monster), Canvas.GetLeft(monster), "boom2");
                level++;
                IsMonsterLevel = false;
                Canvas.SetTop(monster, -188);
                Canvas.SetLeft(monster, 55);
                monster.Opacity = 0;
                Congratulation con = new Congratulation(level, mainCanvas, this);
                mainCanvas.Children.Add(con);
                Canvas.SetTop(con, 100);
                RockAngle = (RockAngle + 5) % 75;
                attckTimer.Interval = TimeSpan.FromMilliseconds(60 - (20 * (Speed - 1) + level));
            }
        }

        private void monsterLife_Loaded(object sender, RoutedEventArgs e)
        {
            monsterLife.Value = 100;
            monsterLife.Foreground = Brushes.Green;
        }

        private void window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            size.Width = e.NewSize.Width;
            size.Height = e.NewSize.Height;
        }
    } // end class
} // end namespace
