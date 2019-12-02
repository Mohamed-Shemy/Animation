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
using System.IO;

namespace Animation
{
    /// <summary>
    /// Interaction logic for PlayerName.xaml
    /// </summary>
    public partial class PlayerName : Window
    {
        double score;
        int level;
        public PlayerName(string _title,double _score , int _level)
        {
            InitializeComponent();
            score = _score;
            level = _level;
            Title.Text = _title;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                if (txt.Text.Length > 0)
                {
                    string fileName = "players";
                    FileStream output = new FileStream(fileName, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write);
                    StreamWriter fileWriter = new StreamWriter(output);
                    fileWriter.WriteLine(string.Format("{0}#{1}#{2}", txt.Text, score, level));
                    fileWriter.Close();
                    this.Close();
                }
        }
    }
}
