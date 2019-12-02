using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;



namespace Animation
{
    /// <summary>
    /// Interaction logic for PlayersList.xaml
    /// </summary>
    public partial class PlayersList : UserControl
    {
        private Canvas mainCanvas;

        public PlayersList()
        {
            InitializeComponent();
        }

        public PlayersList(Canvas mainCanvas)
        {
            InitializeComponent();
            this.mainCanvas = mainCanvas;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            mainCanvas.Children.Remove(this);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            StreamReader fileReader = null;
            try
            {
                string fileName = "players";
                FileStream input = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                fileReader = new StreamReader(input);
                string[] data;
                int i = 1;
                List<Players> players = new List<Players>();
                while (!fileReader.EndOfStream)
                {
                    data = fileReader.ReadLine().Split('#');
                    players.Add(new Players { Number = i, Name = data[0], Score = double.Parse(data[1]), Level = int.Parse(data[2]) });
                    i++;
                }
                for (int j = 0; j < players.Count; j++)
                    listView.Items.Add(players[j]);
            }
            catch (Exception ex)
            { }
            finally
            {
                if (fileReader != null)
                    fileReader.Close();
            }
        }

    }

    public class Players
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public double Score { get; set; }
        public int Level { get; set; }
    }
}
